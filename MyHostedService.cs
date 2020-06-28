using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace js.HostedService
{
    public class MyHostedService : IHostedService
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(MyTask, null, 0, 10000);
            return Task.CompletedTask;
        }

        void MyTask(object state)
        {
            Debug.WriteLine("Executed My Task!!!");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
