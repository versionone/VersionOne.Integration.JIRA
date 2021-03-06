/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using System.Collections.Generic;

namespace VersionOne.ServiceHost.WorkitemServices {
    public class WorkitemStateChangeCollection : List<WorkitemStateChangeResult> {
        public DateTime QueryTimeStamp { get; set; }
        public string LastCheckedDefectId { get; set; }
        public bool ChangesProcessed { internal get; set; }
    }
}