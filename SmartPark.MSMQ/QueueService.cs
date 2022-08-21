using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;

namespace SmartPark.MSMQ
{
    public class QueueService
    {
        public void QueueMessage(MSMQEmail message)
        {
            try
            {
                Message msg = new Message();
                msg.Body = message;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
           //     string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartParkemail";    
                //FormatName:DIRECT=OS:VIRCS-TMRS01\private$\InstrumentationQueue
                string queuePath = ConfigurationManager.AppSettings["MSMQQueuePath"]+ "\\smartParkemail"; 
                
             
              //    string queuePath = ".\\private$\\SmartParkEmail";
                MessageQueue msgQ ;
                //if this queue doesn't exist we will create it
                //if (!MessageQueue.Exists(queuePath))
                //    MessageQueue.Create(queuePath);
                msgQ = new MessageQueue(queuePath);
                msgQ.Formatter = new BinaryMessageFormatter();
                // msgQ.Authenticate = false;
                //msgQ.FormatName= new mes
                string lbgl ="";
                if( message.To!=null)
                {
                lbgl= message.To.ToString();
                }
                msgQ.Send(msg, lbgl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public void QueueActivationEmail(MSMQEmail message)
        {
            try
            {
                Message msg = new Message();
                msg.Body = message;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
                //     string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartParkemail";    
                //FormatName:DIRECT=OS:VIRCS-TMRS01\private$\InstrumentationQueue
                string queuePath = ConfigurationManager.AppSettings["MSMQQueuePath"] + "\\activationEmail";


                //    string queuePath = ".\\private$\\SmartParkEmail";
                MessageQueue msgQ;
                //if this queue doesn't exist we will create it
                //if (!MessageQueue.Exists(queuePath))
                //    MessageQueue.Create(queuePath);
                msgQ = new MessageQueue(queuePath);
                msgQ.Formatter = new BinaryMessageFormatter();
                // msgQ.Authenticate = false;
                //msgQ.FormatName= new mes
                string lbgl = "";
                if (message.To != null)
                {
                    lbgl = message.To.ToString();
                }
                msgQ.Send(msg, lbgl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }


        //this is called from portal / admin section when user apply for new RFID
        public void QueueRFIDMessage(MSMQRFID messages)
        {
            try
            {//180.149.246.109
                //206.183.111.252
                Message msg = new Message();
                msg.Body = messages;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
                //string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartpark";         liver server setup
               // string queuePath = ".\\private$\\RFIDCharge";
                string queuePath = ConfigurationManager.AppSettings["MSMQQueuePath"] + "\\rfidcharge";
                MessageQueue msgQ;
                //if this queue doesn't exist we will create it
                //if (!MessageQueue.Exists(queuePath))
                //    MessageQueue.Create(queuePath);
                msgQ = new MessageQueue(queuePath);
                msgQ.Formatter = new BinaryMessageFormatter();
                // msgQ.Authenticate = false;
                //msgQ.FormatName= new mes
                msgQ.Send(msg, messages.SubscriberID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }


        //This is call when 
        public void QueueTransactionFailedLogMessage(PaymentFailureLog message)
        {
            try
            {//180.149.246.109
                //206.183.111.252
                Message msg = new Message();
                msg.Body = message;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
                //string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartpark";         liver server setup
               // string queuePath = ".\\private$\\transactionfailurelog";
                string queuePath = ConfigurationManager.AppSettings["MSMQQueuePath"] + "\\transactionfailurelog";
                MessageQueue msgQ;
                //if this queue doesn't exist we will create it
                //if (!MessageQueue.Exists(queuePath))
                //    MessageQueue.Create(queuePath);
                using (msgQ = new MessageQueue(queuePath))
                {
                    msgQ.Formatter = new BinaryMessageFormatter();
                  
                    // msgQ.Authenticate = false;
                    //msgQ.FormatName= new mes
                    msgQ.Send(msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }


        public void QueueGetTokeIDFromPaymentGateway(MSMQPaymentGateway message)
        {
            try
            {//180.149.246.109
                //206.183.111.252
                Message msg = new Message();
                msg.Body = message;
                msg.Recoverable = true;
                msg.Formatter = new BinaryMessageFormatter();
                //string queuePath = "FormatName:Direct=TCP:206.183.111.252\\private$\\smartpark";         liver server setup
                // string queuePath = ".\\private$\\transactionfailurelog";
                string queuePath = ConfigurationManager.AppSettings["MSMQQueuePath"] + "\\ewaytoken";
                MessageQueue msgQ;
                //if this queue doesn't exist we will create it
                //if (!MessageQueue.Exists(queuePath))
                //    MessageQueue.Create(queuePath);

                string lable = message.SubscriberID.ToString();
                using (msgQ = new MessageQueue(queuePath))
                {
                    msgQ.Formatter = new BinaryMessageFormatter();

                    // msgQ.Authenticate = false;
                    //msgQ.FormatName= new mes
                    msgQ.Send(msg, lable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        
        }
    }
}
