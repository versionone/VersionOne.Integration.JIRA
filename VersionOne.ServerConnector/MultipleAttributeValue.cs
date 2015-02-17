/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.ServerConnector {
    internal class MultipleAttributeValue : AttributeValue {
        internal readonly object[] Values;
        
        public MultipleAttributeValue(string name, object[] values) : base(name) {
            Values = values;
        }
    }
}