using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSharp.Model
{
    [Serializable]
    public class MyStopwatch : System.Runtime.Serialization.ISerializable
    {
        private TimeSpan lastStopElapsed = TimeSpan.Zero;
        private DateTime lastStartTime;
        private bool isRunning;

        public TimeSpan Elapsed
        {
            get
            {
                if (this.isRunning)
                    return DateTime.Now - this.lastStartTime + this.lastStopElapsed;
                else
                    return this.lastStopElapsed;
            }
            set { lastStopElapsed = value; }
        }

        public long ElapsedMilliseconds
        {
            get
            {
                return (long)this.Elapsed.TotalMilliseconds;
            }
        }

        public long ElapsedTicks
        {
            get
            {
                return this.Elapsed.Ticks;
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }

        public void Start()
        {
            if (!this.isRunning)
            {
                this.lastStartTime = DateTime.Now;
                this.isRunning = true;
            }
        }

        public MyStopwatch(TimeSpan elapsed = default(TimeSpan))
        {
            this.lastStopElapsed = elapsed;
        }


        public static MyStopwatch StartNew(TimeSpan elapsed = default(TimeSpan))
        {
            MyStopwatch stopwatch = new Model.MyStopwatch(elapsed);
            stopwatch.Start();
            return stopwatch;
        }

        public void Stop()
        {
            if (this.isRunning)
            {
                this.lastStopElapsed += DateTime.Now - lastStartTime;
                this.isRunning = false;
            }
        }

        public void Reset()
        {
            this.lastStopElapsed = TimeSpan.Zero;
            this.isRunning = false;
        }

        public void Restart()
        {
            this.lastStartTime = DateTime.Now;
            this.lastStopElapsed = TimeSpan.Zero;
            this.isRunning = true;
        }

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("elapsed", this.Elapsed, typeof(TimeSpan));
        }

        public MyStopwatch(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        {
            this.lastStopElapsed = (TimeSpan)info.GetValue("elapsed", typeof(TimeSpan));
        }
    }
}
