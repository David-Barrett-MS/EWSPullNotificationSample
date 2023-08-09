/*
 * By David Barrett, Microsoft Ltd. 2015. Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using Microsoft.Exchange.WebServices.Data;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using EWSSPullNotificationSample.Auth;

namespace EWSPullNotificationSample
{
    public partial class FormMain : Form
    {
        Logger _logger=null;
        ExchangeService _service = null;
        PullSubscription _subscription = null;
        static bool _ignoreCert = false;
        static Dictionary<string, string> _wellKnownFolders = null;
        int _timerTick = 0;
        CredentialHandler _credentialHandler = null;
        int _consecutiveGetEventsErrors = 0;

        public FormMain()
        {
            InitializeComponent();

            // Create our logger
            InitSubscribeCombo();
            _logger = new Logger("Notifications.log");

            ServicePointManager.ServerCertificateValidationCallback = ValidateCertificate;

            comboBoxSubscribeTo.SelectedIndex = 5; // Set to Inbox first of all
            comboBoxExchangeVersion.SelectedIndex = 5; // Set to Exchange 2013 first of all
            checkedListBoxEvents.SetItemChecked(0, true);

            ToggleMailboxEnabled();
            UpdateAuthUI();
            timerPoll.Interval = 1000;
        }

        private void InitSubscribeCombo()
        {
            InitWellKnownFolders();
            comboBoxSubscribeTo.Items.Clear();
            comboBoxSubscribeTo.Items.Add("All Folders");
            foreach (string wkf in _wellKnownFolders.Keys)
            {
                comboBoxSubscribeTo.Items.Add(wkf);
            }
        }

        private static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if ( _ignoreCert || (errors == SslPolicyErrors.None) )
                return true;

            return false;
        }
        
        void ProcessNotification(object e)
        {
            // We have received a notification
            string sEvent = "";

            if (e is ItemEvent)
            {
                if (!checkBoxShowItemEvents.Checked) return; // We're ignoring item events
                sEvent = "Item " + (e as ItemEvent).EventType.ToString() + ": ";
            }
            else if (e is FolderEvent)
            {
                if (!checkBoxShowFolderEvents.Checked) return; // We're ignoring folder events
                sEvent = "Folder " + (e as FolderEvent).EventType.ToString() + ": ";
            }

            try
            {
                if (checkBoxQueryMore.Checked)
                {
                    // We want more information, we'll get this on a new thread
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(ShowMoreInfo), e);
                    ShowMoreInfo(e);
                }
                else
                {
                    // Just log event and ID
                    if (e is ItemEvent)
                    {
                        sEvent += "ItemId = " + (e as ItemEvent).ItemId.UniqueId;
                    }
                    else if (e is FolderEvent)
                    {
                        sEvent += "FolderId = " + (e as FolderEvent).FolderId.UniqueId;
                    }
                }
            }
            catch { }

            if (checkBoxQueryMore.Checked)
                return;

            ShowEvent(sEvent);
        }

        void ShowMoreInfo(object e)
        {
            // Get more info for the given item.  This runs on its own thread
            // so that the main program can continue as usual (we won't hold anything up)

            string sEvent = "";
            if (e is ItemEvent)
            {
                sEvent = "Item " + (e as ItemEvent).EventType.ToString() + ": " + MoreItemInfo(e as ItemEvent);
            }
            else
                sEvent = "Folder " + (e as FolderEvent).EventType.ToString() + ": " + MoreFolderInfo(e as FolderEvent);

            ShowEvent(sEvent);
        }

        private string MoreItemInfo(ItemEvent e)
        {
            string sMoreInfo = "";
            if (e.EventType == EventType.Deleted)
            {
                // We cannot get more info for a deleted item by binding to it, so skip item details
            }
            else
                sMoreInfo += GetItemInfo(e.ItemId);
            if (e.ParentFolderId != null)
            {
                if (!String.IsNullOrEmpty(sMoreInfo)) sMoreInfo += ", ";
                sMoreInfo += "Parent Folder Name=" + GetFolderName(e.ParentFolderId);
            }
            return sMoreInfo;
        }

        private string MoreFolderInfo(FolderEvent e)
        {
            string sMoreInfo = "";
            if (e.EventType == EventType.Deleted)
            {
                // We cannot get more info for a deleted item by binding to it, so skip item details
            }
            else
                sMoreInfo += "Folder name=" + GetFolderName(e.FolderId);
            if (e.ParentFolderId != null)
            {
                if (!String.IsNullOrEmpty(sMoreInfo)) sMoreInfo += ", ";
                sMoreInfo += "Parent Folder Name=" + GetFolderName(e.ParentFolderId);
            }
            return sMoreInfo;
        }

        private string GetItemInfo(ItemId itemId)
        {
            // Retrieve the subject for a given item
            string sItemInfo = "";
            Item oItem;
            PropertySet oPropertySet;

            oPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
            if (checkBoxIncludeMime.Checked)
            {
                oPropertySet.Add(ItemSchema.MimeContent);
            }

            GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
            SetClientRequestId();
            try
            {
                oItem = Item.Bind(_service, itemId, oPropertySet);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            if (oItem is Appointment)
            {
                sItemInfo += "Appointment subject=" + oItem.Subject;
                // Show attendee information
                Appointment oAppt=oItem as Appointment;
                sItemInfo += ",RequiredAttendees=" + GetAttendees(oAppt.RequiredAttendees);
                sItemInfo += ",OptionalAttendees=" + GetAttendees(oAppt.OptionalAttendees);
            }
            else if (oItem is MeetingMessage)
            {
                // We have a meeting response, so we locate the appointment to which this response applies
                try
                {
                    sItemInfo += "Meeting update";
                    GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
                    SetClientRequestId();
                    Appointment oAppointment = Appointment.Bind(_service, (oItem as MeetingMessage).AssociatedAppointmentId);
                    sItemInfo += ", appointment subject=" + oAppointment.Subject;
                    sItemInfo += ", start time=" + oAppointment.Subject;
                    // Show attendee information
                    sItemInfo += ", RequiredAttendees=" + GetAttendees(oAppointment.RequiredAttendees);
                    sItemInfo += ", OptionalAttendees=" + GetAttendees(oAppointment.OptionalAttendees);
                }
                catch
                {

                }
            }
            else
                sItemInfo += "Item subject=" + oItem.Subject;
            if (checkBoxIncludeMime.Checked)
                sItemInfo += ", MIME length=" + oItem.MimeContent.Content.Length.ToString() + " bytes";
            return sItemInfo;
        }

        private string GetAttendees(AttendeeCollection attendees)
        {
            if (attendees.Count == 0) return "none";

            string sAttendees = "";
            foreach (Attendee attendee in attendees)
            {
                if (!String.IsNullOrEmpty(sAttendees))
                    sAttendees += ", ";
                sAttendees += attendee.Name;
            }

            return sAttendees;
        }

        private string GetFolderName(FolderId folderId)
        {
            // Retrieve display name of the given folder
            GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
            SetClientRequestId();
            try
            {
                Folder oFolder = Folder.Bind(_service, folderId, new PropertySet(FolderSchema.DisplayName));
                return oFolder.DisplayName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void ShowEvent(string eventDetails)
        {
            string loggedData = _logger.Log(eventDetails);
            Action action = new Action(() =>
            {
                listBoxEvents.Items.Add(loggedData);
                listBoxEvents.SelectedIndex = listBoxEvents.Items.Count - 1;
            });
            if (listBoxEvents.InvokeRequired)
                listBoxEvents.Invoke(action);
            else
                action();
        }

        private EventType[] SelectedEvents()
        {
            // Read the selected events

            if (checkedListBoxEvents.CheckedItems.Count < 1)
                return null;
            EventType[] events = new EventType[checkedListBoxEvents.CheckedItems.Count];

            for (int i = 0; i < checkedListBoxEvents.CheckedItems.Count; i++)
            {
                switch (checkedListBoxEvents.CheckedItems[i].ToString())
                {
                    case "NewMail": { events[i] = EventType.NewMail; break; }
                    case "Deleted": { events[i] = EventType.Deleted; break; }
                    case "Modified": { events[i] = EventType.Modified; break; }
                    case "Moved": { events[i] = EventType.Moved; break; }
                    case "Copied": { events[i] = EventType.Copied; break; }
                    case "Created": { events[i] = EventType.Created; break; }
                    case "FreeBusyChanged": { events[i] = EventType.FreeBusyChanged; break; }
                }
            }

            return events;
        }

        private void InitWellKnownFolders()
        {
            if (_wellKnownFolders != null)
            {
                if (_wellKnownFolders.Count > 0)
                    return; // Already initialised
            }

            _wellKnownFolders = new Dictionary<string, string>
            {
                { "Calendar", "Calendar" },
                { "Contacts", "Contacts" },
                { "Deleted Items", "DeletedItems" },
                { "Drafts", "Drafts" },
                { "Inbox", "Inbox" },
                { "Journal", "Journal" },
                { "Notes", "Notes" },
                { "Outbox", "Outbox" },
                { "Sent Items", "SentItems" },
                { "Tasks", "Tasks" },
                { "Message Folders Root (Top of Information Store)", "MsgFolderRoot" },
                { "Public Folders Root", "PublicFoldersRoot" }
            };
        }

        private void GetSubfolders(FolderId ParentFolderId, ref List<FolderId> FolderIdList)
        {
            int offset = 0;
            bool moreFolders = true;

            FolderView folderView = new FolderView(500);
            folderView.PropertySet = new PropertySet(BasePropertySet.IdOnly, FolderSchema.ChildFolderCount);
            // Public folders don't support deep traversal, so we set to shallow in case we are looking at public folders
            // This means we also need to recurse if our subfolders have subfolders
            folderView.Traversal = FolderTraversal.Shallow; 

            while (moreFolders)
            {
                folderView.Offset = offset;
                GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
                SetClientRequestId();
                FindFoldersResults results = _service.FindFolders(ParentFolderId, folderView);
                moreFolders = results.MoreAvailable;
                offset += 500;
                foreach (Folder folder in results)
                {
                    FolderIdList.Add(folder.Id);
                    if (folder.ChildFolderCount > 0)
                        GetSubfolders(folder.Id, ref FolderIdList);
                }
            }
        }

        private FolderId[] SubscribedFolders()
        {
            List<FolderId> folderIds = new List<FolderId>();
            Mailbox mailbox = null;
            if (!String.IsNullOrEmpty(textBoxMailbox.Text))
                mailbox = new Mailbox(textBoxMailbox.Text);

            if (!_wellKnownFolders.ContainsKey(comboBoxSubscribeTo.Text))
            {
                folderIds.Add(new FolderId(comboBoxSubscribeTo.Text));
            }
            else
            {
                if (mailbox != null)
                    folderIds.Add(new FolderId((WellKnownFolderName)Enum.Parse(typeof(WellKnownFolderName), _wellKnownFolders[comboBoxSubscribeTo.Text]), mailbox));
                else
                    folderIds.Add((WellKnownFolderName)Enum.Parse(typeof(WellKnownFolderName), _wellKnownFolders[comboBoxSubscribeTo.Text]));
            }

            if (checkBoxIncludeSubfolders.Checked)
            {
                // Need to retrieve Ids of all subfolders as well
                GetSubfolders(folderIds[0], ref folderIds);
            }

            return folderIds.ToArray<FolderId>();
        }

        private void buttonSubscribe_Click(object sender, EventArgs e)
        {
            if (!InitEWS()) return;

            try
            {
                _subscription = null;
                GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
                SetClientRequestId();

                if (comboBoxSubscribeTo.SelectedItem.ToString() == "All Folders")
                {
                    if (comboBoxExchangeVersion.SelectedIndex < 1)
                    {
                        System.Windows.Forms.MessageBox.Show("Need at least Exchange 2010 to subscribe to all folders", "Unsupported",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _subscription = _service.SubscribeToPullNotificationsOnAllFolders((int)numericUpDownTimeout.Value, textBoxWatermark.Text, SelectedEvents());
                }
                else
                    _subscription = _service.SubscribeToPullNotifications(SubscribedFolders(), (int)numericUpDownTimeout.Value, textBoxWatermark.Text, SelectedEvents());
                if (_subscription != null)
                {
                    ShowEvent("Subscribed successfully, subscription Id is " + _subscription.Id);
                    _consecutiveGetEventsErrors = 0;
                    textBoxLastWatermark.Text = _subscription.Watermark;
                    buttonSubscribe.Enabled = false;
                    buttonUnsubscribe.Enabled = true;
                    if (checkBoxAutoPoll.Checked)
                        timerPoll.Start();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Failed to subscribe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _service = null;
                return;
            }
        }

        private CredentialHandler GetCredentialHandler()
        {
            if (_credentialHandler != null)
                return _credentialHandler;

            if (radioButtonAuthBasic.Checked)
            {
                _credentialHandler = new CredentialHandler(AuthType.Basic);
                _credentialHandler.Username = textBoxUsername.Text;
                _credentialHandler.Password = textBoxPassword.Text;
                return _credentialHandler;
            }

            _credentialHandler = new CredentialHandler(AuthType.OAuth);
            _credentialHandler.TenantId = textBoxTenantId.Text;
            _credentialHandler.ApplicationId = textBoxApplicationId.Text;

            if (radioButtonAuthWithClientSecret.Checked)
                _credentialHandler.ClientSecret = textBoxClientSecret.Text;
            else if (radioButtonAuthWithCertificate.Checked)
                _credentialHandler.Certificate = (X509Certificate2)textBoxAuthCertificate.Tag;

            return _credentialHandler;
        }

        public static void SetXAnchorMailbox(ExchangeService exchange, string xAnchorMailbox)
        {
            if (exchange.HttpHeaders.ContainsKey("X-AnchorMailbox"))
                exchange.HttpHeaders.Remove("X-AnchorMailbox");
            exchange.HttpHeaders.Add("X-AnchorMailbox", xAnchorMailbox);
        }

        private bool InitEWS()
        {
            try
            {
                switch (comboBoxExchangeVersion.Text)
                {
                    case "Exchange2007_SP1": _service = new ExchangeService(ExchangeVersion.Exchange2007_SP1); break;
                    case "Exchange2010": _service = new ExchangeService(ExchangeVersion.Exchange2010); break;
                    case "Exchange2010_SP1": _service = new ExchangeService(ExchangeVersion.Exchange2010_SP1); break;
                    case "Exchange2010_SP2": _service = new ExchangeService(ExchangeVersion.Exchange2010_SP2); break;
                    case "Exchange2013": _service = new ExchangeService(ExchangeVersion.Exchange2013); break;
                    case "Exchange2013_SP1": _service = new ExchangeService(ExchangeVersion.Exchange2013_SP1); break;
                    default: _service = new ExchangeService(); break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Failed to create service",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            GetCredentialHandler().ApplyCredentialsToExchangeService(_service);

            _ignoreCert = checkBoxIgnoreCert.Checked;
            _service.ReturnClientRequestId = true;

            if (radioButtonAutodiscover.Checked)
            {
                try
                {
                    SetClientRequestId();
                    _service.AutodiscoverUrl(textBoxMailbox.Text);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Failed to autodiscover URL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (radioButtonExchangeOnline.Checked)
                _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
            else
                _service.Url = new Uri(textBoxEwsUrl.Text);

            _service.TraceListener = new EWSTracer("trace.log");
            _service.TraceFlags = TraceFlags.All;
            _service.TraceEnabled = true;

            if (checkBoxImpersonate.Checked)
            {
                _service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, textBoxMailbox.Text);
                SetXAnchorMailbox(_service, textBoxMailbox.Text);
            }

            return true;
        }

        private void SetClientRequestId()
        {
            if (_service == null) return;
            _service.ClientRequestId = Guid.NewGuid().ToString();
        }

        private void comboBoxSubscribeTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubscribeTo.SelectedIndex != 0) return;

            // Has been set to All Folders, so need to ensure Exchange version is minimum 2010
            if (comboBoxExchangeVersion.SelectedIndex < 1)
                comboBoxExchangeVersion.SelectedIndex = 1;
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = true;
            if (checkBoxSelectAll.CheckState == CheckState.Unchecked)
                bChecked=false;

            for (int i = 0; i < checkedListBoxEvents.Items.Count; i++)
                checkedListBoxEvents.SetItemChecked(i, bChecked);
            if (bChecked)
            {
                checkBoxSelectAll.CheckState = CheckState.Checked;
            }
            else
                checkBoxSelectAll.CheckState = CheckState.Unchecked;
        }

        private void checkedListBoxEvents_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxEvents.Items.Count != checkedListBoxEvents.SelectedItems.Count)
                checkBoxSelectAll.CheckState = CheckState.Indeterminate;
        }

        private void checkBoxQueryMore_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxIncludeMime.Enabled = checkBoxQueryMore.Checked;
        }

        private string CurrentUserEmailAddress()
        {
            // Determine the current user's email address (assuming AD environment)

            try
            {
                string sFilter = String.Format("(&(samAccountName={0})(objectCategory=person)(objectClass=user))", Environment.UserName);

                DirectorySearcher oSearcher = new DirectorySearcher(sFilter);
                oSearcher.PropertiesToLoad.Add("mail");
                SearchResultCollection oResults = oSearcher.FindAll();
                oSearcher.Dispose();
                if (oResults.Count != 1)
                    return null;

                return oResults[0].Properties["mail"][0].ToString();
            }
            catch
            {
                return null;
            }
        }

        private void GetEvents(object e)
        {
            bool bMoreEvents = true;
            Action action;
            while (bMoreEvents)
            {
                GetEventsResults oResults = null;
                GetCredentialHandler().ApplyCredentialsToExchangeService(_service);
                SetClientRequestId();
                try
                {
                    oResults = _subscription.GetEvents();
                    _consecutiveGetEventsErrors = 0;
                }
                catch (Exception ex)
                {
                    bMoreEvents = false;
                    _consecutiveGetEventsErrors++;
                    ShowEvent(String.Format("Error occurred retrieving events: {0}", ex.Message));
                    if (ex.Message == "The specified subscription was not found.")
                    {
                        // Need to re-subscribe
                        action = new Action(()=>
                        {
                            if (!String.IsNullOrEmpty(textBoxLastWatermark.Text) && textBoxWatermark.Text != textBoxLastWatermark.Text)
                                textBoxWatermark.Text = textBoxLastWatermark.Text;
                            buttonSubscribe_Click(null, null);
                        });
                        if (buttonSubscribe.InvokeRequired)
                            buttonSubscribe.Invoke(action);
                        else
                            action();
                        return;
                    }
                    if (_consecutiveGetEventsErrors>5)
                    {
                        ShowEvent("Too many consecutive errors retrieving events, stopping subscription");
                        action = new Action(() =>
                        {
                            buttonUnsubscribe_Click(null, null);
                        });
                        if (buttonUnsubscribe.InvokeRequired)
                            buttonUnsubscribe.Invoke(action);
                        else
                            action();
                        return;
                    }
                }

                if (oResults != null)
                {
                    action = new Action(() =>
                    {
                        textBoxLastWatermark.Text = _subscription.Watermark;
                    });
                    if (textBoxLastWatermark.InvokeRequired)
                        textBoxLastWatermark.Invoke(action);
                    else
                        action.Invoke();
                    bMoreEvents = (bool)_subscription.MoreEventsAvailable;

                    if (bMoreEvents && (oResults.AllEvents.Count == 0))
                    {
                        // We have MoreEvents set, but no events... This is a problem!
                        ShowEvent("WARNING: MoreItems = true, but we weren't sent any events");
                    }

                    foreach (NotificationEvent n in oResults.AllEvents)
                    {
                        ProcessNotification(n);
                    }
                }
            }

            action = new Action(() =>
            {
                buttonPoll.Text = "Poll for events";
                buttonPoll.Enabled = true;

                if (checkBoxAutoPoll.Checked)
                    timerPoll.Start();
            });
            if (buttonPoll.InvokeRequired)
                buttonPoll.Invoke(action);
            else
                action.Invoke();

        }

        private void buttonPoll_Click(object sender, EventArgs e)
        {
            if (_subscription == null) return;

            buttonPoll.Text = "Polling...";
            buttonPoll.Enabled = false;

            // We do the work on a background thread so we don't block the UI
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetEvents), e);
        }

        private void checkBoxAutoPoll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoPoll.Checked)
            {
                // Enable autopolling
                timerPoll.Start();
            }
            else
                timerPoll.Stop();
        }

        private void timerPoll_Tick(object sender, EventArgs e)
        {
            _timerTick++;
            if (_timerTick < numericUpDownPollInterval.Value) return;

            timerPoll.Stop();
            _timerTick = 0;
            buttonPoll_Click(null, null);
        }

        private void listBoxEvents_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sInfo = listBoxEvents.SelectedItem.ToString();
                System.Windows.Forms.MessageBox.Show(sInfo, "Event", MessageBoxButtons.OK);
            }
            catch { }
        }

        private void numericUpDownPollInterval_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ToggleMailboxEnabled()
        {
            textBoxMailbox.Enabled = comboBoxSubscribeTo.SelectedIndex!=0;
            textBoxEwsUrl.Enabled = !radioButtonAutodiscover.Checked;
            checkBoxIgnoreCert.Enabled = !radioButtonExchangeOnline.Checked;
        }
        private void radioButtonAutodiscover_CheckedChanged(object sender, EventArgs e)
        {
            ToggleMailboxEnabled();
        }

        private void radioButtonEwsUrl_CheckedChanged(object sender, EventArgs e)
        {
            ToggleMailboxEnabled();
        }

        private void buttonSelectCertificate_Click(object sender, EventArgs e)
        {

        }

        private void buttonUnsubscribe_Click(object sender, EventArgs e)
        {
            timerPoll.Stop();
            if (_subscription!=null)
            {
                try
                {
                    _subscription.Unsubscribe();
                    ShowEvent($"Unsubscribed successfully: {_subscription.Id}");
                }
                catch (Exception ex)
                {
                    ShowEvent($"Error on unsubscribe: {ex.Message}");
                }
                _subscription = null;
            }

            buttonSubscribe.Enabled = true;
            buttonUnsubscribe.Enabled = false;
        }
        
        private void UpdateAuthUI()
        {
            textBoxApplicationId.Enabled = radioButtonAuthOAuth.Checked;
            textBoxTenantId.Enabled = radioButtonAuthOAuth.Checked;

            if (radioButtonAuthOAuth.Checked)
            {
                textBoxClientSecret.Enabled = radioButtonAuthWithClientSecret.Checked;
                textBoxAuthCertificate.Enabled = radioButtonAuthWithCertificate.Checked;
                buttonSelectCertificate.Enabled = radioButtonAuthWithCertificate.Checked;

                checkBoxImpersonate.Checked = !radioButtonAuthClientCredentials.Checked;
                checkBoxImpersonate.Enabled = false;
                return;
            }

            textBoxClientSecret.Enabled = false;
            textBoxAuthCertificate.Enabled = false;
            buttonSelectCertificate.Enabled = false;

            checkBoxImpersonate.Enabled = true;
        }

        private void radioButtonAuthOAuth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void radioButtonAuthBasic_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void radioButtonAuthClientCredentials_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void radioButtonAuthWithClientSecret_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void radioButtonAuthWithCertificate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }
    }
}
