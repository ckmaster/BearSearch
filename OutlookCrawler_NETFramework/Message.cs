using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace OutlookCrawler_NetFramework
{
    class Message
    {
        public Message(MailItem item)
        {
            //this.attachments = item.Attachments;
            this.bcc = item.BCC;
            this.body = item.Body;
            this.categories = item.Categories;
            this.cc = item.CC;
            //this.companies = item.Companies;
            this.conversationID = item.ConversationID;
            this.conversationIndex = item.ConversationIndex;
            this.conversationTopic = item.ConversationTopic;
            this.creationTime = item.CreationTime;
            this.entryID = item.EntryID;
            //this.flagRequest = item.FlagRequest;
            this.importance = item.Importance;
            this.isMarkedAsTask = item.IsMarkedAsTask;
            this.itemProperties = item.ItemProperties;
            this.lastModificationTime = item.LastModificationTime;
            this.messageClass = item.MessageClass;
            //this.originatorDeliveryReportRequested = item.OriginatorDeliveryReportRequested;
            this.parent = item.Parent;
            //this.readReceiptRequested = item.ReadReceiptRequested;
            this.receivedByEntryID = item.ReceivedByEntryID;
            this.receivedByName = item.ReceivedByName;
            this.receivedOnBehalfOfEntryID = item.ReceivedOnBehalfOfEntryID;
            this.receivedOnBehalfOfName = item.ReceivedOnBehalfOfName;
            this.receivedTime = item.ReceivedTime;
            this.recipients = item.Recipients;
            this.replyRecipientNames = item.ReplyRecipientNames;
            this.replyRecipients = item.ReplyRecipients;
            this.retentionExpirationDate = item.RetentionExpirationDate;
            this.retentionPolicyName = item.RetentionPolicyName;
            this.sender = item.Sender;
            this.senderEmailAddress = item.SenderEmailAddress;
            this.senderEmailType = item.SenderEmailType;
            this.sendUsingAccount = item.SendUsingAccount;
            //this.sent = item.Sent;
            this.sentOn = item.SentOn;
            this.sentOnBehalfOfName = item.SentOnBehalfOfName;
            this.size = item.Size;
            this.subject = item.Subject;
            this.taskCompletedDate = item.TaskCompletedDate;
            this.taskDueDate = item.TaskDueDate;
            this.taskStartDate = item.TaskStartDate;
            this.taskSubject = item.TaskSubject;
            this.to = item.To;
            //this.unread = item.UnRead;
            this.userProperties = item.UserProperties;
            this.votingOptions = item.VotingOptions;
            this.votingResponse = item.VotingResponse;
        }

        //public Attachments attachments { get; }
        public string bcc { get; }
        public string body { get; }
        //public OIBodyFormat oIBodyFormat { get; }
        public string categories { get; }
        public string cc { get; }
       // public string companies { get; }
        public string conversationID { get; }
        public string conversationIndex { get; }
        public string conversationTopic { get; }
        public DateTime creationTime { get; }
        public string entryID { get; }
        //public string flagRequest { get; }
        //public string htmlBody { get; }
        //TODO Look at mapping importance to useful values
        public OlImportance importance { get; }
        public bool isMarkedAsTask { get; }
        //TODO figure out if anything useful can be in itemProperties
        public ItemProperties itemProperties { get; }
        public DateTime lastModificationTime { get; }
        //TODO figure out messageClass possible values
        public string messageClass { get; }
        //public bool originatorDeliveryReportRequested { get; }
        public object parent { get; }
        //public bool readReceiptRequested { get; }
        public string receivedByEntryID { get; }
        public string receivedByName { get; }
        public string receivedOnBehalfOfEntryID { get; }
        public string receivedOnBehalfOfName { get; }
        public DateTime receivedTime { get; }
        public Recipients recipients { get; }
        public string replyRecipientNames { get; }
        public Recipients replyRecipients { get; }
        public DateTime retentionExpirationDate { get; }
        public string retentionPolicyName { get; }
        //public byte[] rtfBody { get; }
        public AddressEntry sender { get; }
        public string senderEmailAddress { get; }
        public string senderEmailType { get; }
        public string senderName { get; }
        public Account sendUsingAccount { get; }
        //public bool sent { get; }
        public DateTime sentOn { get; }
        public string sentOnBehalfOfName { get; }
        public int size { get; }
        public string subject { get; }
        public DateTime taskCompletedDate { get; }
        public DateTime taskDueDate { get; }
        public DateTime taskStartDate { get; }
        public string taskSubject { get; }
        public string to { get; }
        //public bool unread { get; }
        //TODO figure out if userProperties is useful
        public UserProperties userProperties { get; }
        public string votingOptions { get; }
        public string votingResponse { get; }
    }
}
