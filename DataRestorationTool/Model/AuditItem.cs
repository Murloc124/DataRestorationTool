using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace DataRestorationTool.Model
{
    internal class AuditItem
    {
        public Guid AuditId { get; set; }
        public Guid RecordId { get; set; }
        public string Name { get; set; }
        public string Table { get; set; }
        public EntityMetadata Metadata { get; set; }
        public DateTime DeletionDate { get; set; }
        public string DeletedBy { get; set; }
        public AttributeAuditDetail AuditDetail { get; set; }
    }
}
