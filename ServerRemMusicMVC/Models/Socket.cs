using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerRemMusicMVC.Models
{
    public class _Socket
    {
        public Socket server;

        public _Socket(int port)
        {
             
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, port));
            server.Listen(5);
            AsyncServerwork();
            
        }
        void Work()
        {
            
                Socket handler = server.Accept();
                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байтов
                byte[] data = new byte[256]; // буфер для получаемых данных

                do
            {
                bytes = handler.Receive(data);
                builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);



            //Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

            // отправляем ответ
            string message = builder.ToString();
                data = Encoding.Unicode.GetBytes(message);
               handler.Send(data);

            data = Encoding.Unicode.GetBytes(new String("play"));

            // закрываем сокет
            handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            
            //while (true)
            //{
            //    Socket client = server.Accept();
            //    byte[] buffer = new byte[256];
            //    client.Receive(buffer);
            //}
        }

        async void AsyncServerwork()
        {
            await Task.Run(() => Work());
        }

        ~_Socket()
        {
            server.Shutdown(SocketShutdown.Both);
            server.Close(); 
        }
    }
}
