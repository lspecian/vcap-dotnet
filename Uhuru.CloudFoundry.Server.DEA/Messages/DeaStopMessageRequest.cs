﻿using System;
using System.Collections.Generic;
using Uhuru.Utilities;

namespace Uhuru.CloudFoundry.DEA
{
    public class DeaStopMessageRequest : JsonConvertibleObject
    {
        [JsonName("droplet")]
        public int DropletId
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), 
        JsonName("instances")]
        public HashSet<string> InstanceIds
        {
            get;
            set;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), 
        JsonName("indices")]
        public HashSet<int> Indexes
        {
            get;
            set;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), 
        JsonName("states")]
        public HashSet<string> StatesInterchangeableFormat
        {
            get
            {
                HashSet<string> res = new HashSet<string>();
                foreach (DropletInstanceState state in States)
                {
                    res.Add(state.ToString());
                }
                return res;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                States = new HashSet<DropletInstanceState>();
                foreach (string state in value)
                {
                    States.Add((DropletInstanceState)Enum.Parse(typeof(DropletInstanceState), state));
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public HashSet<DropletInstanceState> States
        {
            get;
            set;
        }
    }
}