using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivedita_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var deviceNames = new Dictionary<string, int>() { };

                //here I have considered that messages send by the devices will get stored in a queue in kay-value format
                //& then they will get processed to get a count of messages send by each device
                //here to test the functionality I have added below example messages in a queue
                Queue<KeyValuePair<int, string>> messagesQueue = new Queue<KeyValuePair<int, string>>();
                messagesQueue.Enqueue(new KeyValuePair<int, string>(3, "voltage 230volts"));//2-voltage 10volts ,  , on
                messagesQueue.Enqueue(new KeyValuePair<int, string>(3, "voltage 10volts"));//2-voltage 10volts ,  , on
                messagesQueue.Enqueue(new KeyValuePair<int, string>(2, "current 0.1 A"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(22, "textmsg"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(3, "statuson"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(11, "voltage 5volts"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(3, "statusoff"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(11, "current 0.2 A"));
                messagesQueue.Enqueue(new KeyValuePair<int, string>(11, "current 0.1 A"));


                foreach (var queueElement in messagesQueue)
                {

                    var deviceNo = queueElement.Key;
                    if (!deviceNames.ContainsKey(("Device" + deviceNo)))
                    {
                        deviceNames.Add("Device" + deviceNo, 1);
                    }
                    else
                    {
                        foreach (var item in deviceNames.ToList().Where(w => w.Key == ("Device" + deviceNo)))
                        {

                            deviceNames[item.Key]++;
                        }
                    }

                }

                foreach (var word in deviceNames.ToList())
                {
                    Console.WriteLine(word.Key + "=" + " " + word.Value);

                }
                Console.ReadLine();
            }
            catch
            {
            }

        }
    }
}
