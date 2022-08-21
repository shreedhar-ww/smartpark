using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SmartPark.MSMQ
{
    public class QueueService
    {
        public void QueueMessage(EmailMessageEntity message)
        {
            try
            {//180.149.246.109
                //206.183.111.252
                Message msg = new Message();
                msg.Body = message;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
                //string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartpark";         liver server setup
                string queuePath = ".\\private$\\SmartParkEmail";
                MessageQueue msgQ;
                //if this queue doesn't exist we will create it
                if (!MessageQueue.Exists(queuePath))
                    MessageQueue.Create(queuePath);
                msgQ = new MessageQueue(queuePath);
                msgQ.Formatter = new BinaryMessageFormatter();
                // msgQ.Authenticate = false;
                //msgQ.FormatName= new mes
                msgQ.Send(msg);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
