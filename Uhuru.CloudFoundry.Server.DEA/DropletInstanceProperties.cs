﻿using System;
using Uhuru.Utilities;

namespace Uhuru.CloudFoundry.DEA
{
    public enum DropletInstanceState
    {
        [JsonName("STARTING")]
        Starting,
        [JsonName("RUNNING")]
        Running,
        [JsonName("STOPPED")]
        Stopped,
        [JsonName("DELETED")]
        Deleted,
        [JsonName("CRASHED")]
        Crashed

    }

    public enum DropletExitReason
    {
        [JsonName("NONE")]
        None,
        [JsonName("DEA_EVACUATION")]
        DeaEvacuation,
        [JsonName("DEA_SHUTDOWN")]
        DeaShutdown,
        [JsonName("STOPPED")]
        Stopped,
        [JsonName("CRASHED")]
        Crashed
    }


    public class DropletInstanceProperties : JsonConvertibleObject
    {


        [JsonName("state")]
        public string StateInterchangeableFormat
        {
            get { return State.ToString(); }
            set { State = (DropletInstanceState)Enum.Parse(typeof(DropletInstanceState), value); }
        }

        private DropletInstanceState state;
        private readonly object stateLock = new object();

        public DropletInstanceState State
        {
            get
            {
                lock (stateLock)
                {
                    return state;
                }
            }
            set
            {
                lock (stateLock)
                {
                    state = value;
                }
            }
        }

        [JsonName("exit_reason")]
        public string ExitReasonInterchangeableFormat
        {
            get { return ExitReason != null ? ExitReason.ToString() : null; }
            set { ExitReason = value != null ? (DropletExitReason?)Enum.Parse(typeof(DropletExitReason), value) : null; }
        }

        public DropletExitReason? ExitReason
        {
            get;
            set;
        }

        [JsonName("orphaned")]
        public bool Orphaned
        {
            get;
            set;
        }

        [JsonName("start")]
        public string StartInterchangeableFormat
        {
            get { return RubyCompatibility.DateTimeToRubyString(Start); }
            set { Start = RubyCompatibility.DateTimeFromRubyString(value); }
        }

        public DateTime Start
        {
            get;
            set;
        }

        [JsonName("state_timestamp")]
        public int StateTimestampInterchangeableFormat
        {
            get { return RubyCompatibility.DateTimeToEpochSeconds(StateTimestamp); }
            set { StateTimestamp = RubyCompatibility.DateTimeFromEpochSeconds(value); }
        }

        public DateTime StateTimestamp
        {
            get;
            set;
        }

        [JsonName("resources_tracked")]
        public bool ResourcesTracked
        {
            get;
            set;
        }


        private readonly object stopProcessedLock = new object();
        private bool stopProcessed;

        [JsonName("stop_processed")]
        public bool StopProcessed
        {
            get
            {
                lock (stopProcessedLock)
                {
                    return stopProcessed;
                }
            }
            set
            {
                lock (stopProcessedLock)
                {
                    stopProcessed = value;
                }
            }
        }

        [JsonName("debug_mode")]
        public string DebugMode
        {
            get;
            set;
        }

        [JsonName("port")]
        public int Port
        {
            get;
            set;
        }

        [JsonName("debug_port")]
        public int? DebugPort
        {
            get;
            set;
        }

        [JsonName("debug_ip")]
        public string DebugIP
        {
            get;
            set;
        }

        [JsonName("runtime")]
        public string Runtime
        {
            get;
            set;
        }

        [JsonName("framework")]
        public string Framework
        {
            get;
            set;
        }

        [JsonName("fds_quota")]
        public long FdsQuota
        {
            get;
            set;
        }

        [JsonName("disk_quota")]
        public long DiskQuotaBytes
        {
            get;
            set;
        }

        [JsonName("mem_quota")]
        public long MemoryQuotaBytes
        {
            get;
            set;
        }

        [JsonName("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonName("instance_id")]
        public string InstanceId
        {
            get;
            set;
        }

        [JsonName("version")]
        public string Version
        {
            get;
            set;
        }

        [JsonName("droplet_id")]
        public int DropletId
        {
            get;
            set;
        }

        [JsonName("instance_index")]
        public int InstanceIndex
        {
            get;
            set;
        }

        [JsonName("dir")]
        public string Directory
        {
            get;
            set;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays"), 
        JsonName("uris")]
        public string[] Uris
        {
            get;
            set;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays"), 
        JsonName("users")]
        public string[] Users
        {
            get;
            set;
        }

        [JsonName("log_id")]
        public string LoggingId
        {
            get;
            set;
        }

        [JsonName("evacuated")]
        public bool Evacuated
        {
            get;
            set;
        }

        [JsonName("pid")]
        public int ProcessId
        {
            get;
            set;
        }

        [JsonName("notified")]
        public bool NotifiedExited
        {
            get;
            set;
        }

        [JsonName("nice")]
        public int Nice
        {
            get;
            set;
        }

        [JsonName("secure_user")]
        public string SecureUser
        {
            get;
            set;
        }

        [JsonName("staged")]
        public string Staged
        {
            get;
            set;
        }

        [JsonName("usage")]
        public DropletInstanceUsage UsageRecent
        {
            get;
            set;
        }


        [JsonName("windows_username")]
        public string WindowsUsername
        {
            get;
            set;
        }

        [JsonName("windows_password")]
        public string WindowsPassword
        {
            get;
            set;
        }

    }
}
