#region Using directives

using System;

#endregion

namespace CPECentral.Data.EF5
{
    public partial class ClientSetting : IEntity, IEquatable<ClientSetting>
    {
        public bool Equals(ClientSetting other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(ClientSetting left, ClientSetting right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ClientSetting left, ClientSetting right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            return Equals((ClientSetting) obj);
        }    
    }

    public partial class Customer : IEntity, IEquatable<Customer>
    {
        #region IEquatable<Customer> Members

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name);
        }

        #endregion

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Customer) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Document : IEntity, IEquatable<Document>
    {
        #region IEquatable<Document> Members

        public bool Equals(Document other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(FileName, other.FileName) && PartId == other.PartId &&
                   PartVersionId == other.PartVersionId && OperationId == other.OperationId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                int hashCode = (FileName != null ? FileName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PartId.GetHashCode();
                hashCode = (hashCode*397) ^ PartVersionId.GetHashCode();
                hashCode = (hashCode*397) ^ OperationId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Document left, Document right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Document left, Document right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Document) obj);
        }

        public override string ToString()
        {
            return FileName;
        }
    }

    public partial class Employee : IEntity, IEquatable<Employee>
    {
        #region IEquatable<Employee> Members

        public bool Equals(Employee other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(UserName, other.UserName);
        }

        #endregion

        public override int GetHashCode()
        {
            return (UserName != null ? UserName.GetHashCode() : 0);
        }

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Employee) obj);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    public partial class EmployeeGroup : IEntity, IEquatable<EmployeeGroup>
    {
        #region IEquatable<EmployeeGroup> Members

        public bool Equals(EmployeeGroup other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name);
        }

        #endregion

        public void GrantPermission(AppPermission permission)
        {
            var p = (AppPermission) Permissions;

            p |= permission;

            Permissions = (int) p;
        }

        public void DenyPermission(AppPermission permission)
        {
            var p = (AppPermission) Permissions;

            p &= ~permission;

            Permissions = (int) p;
        }

        public bool HasPermission(AppPermission permission)
        {
            var p = (AppPermission) Permissions;

            if (p == AppPermission.Administrator) {
                return true;
            }

            return (p & permission) == permission;
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(EmployeeGroup left, EmployeeGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeGroup left, EmployeeGroup right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((EmployeeGroup) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Holder : IEntity, IEquatable<Holder>
    {
        #region IEquatable<Holder> Members

        public bool Equals(Holder other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name) && HolderGroupId == other.HolderGroupId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ HolderGroupId;
            }
        }

        public static bool operator ==(Holder left, Holder right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Holder left, Holder right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Holder) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class HolderGroup : IEntity, IEquatable<HolderGroup>
    {
        #region IEquatable<HolderGroup> Members

        public bool Equals(HolderGroup other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name);
        }

        #endregion

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(HolderGroup left, HolderGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HolderGroup left, HolderGroup right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((HolderGroup) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class HolderTool : IEntity, IEquatable<HolderTool>
    {
        #region IEquatable<HolderTool> Members

        public bool Equals(HolderTool other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return HolderId == other.HolderId && ToolId == other.ToolId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return (HolderId*397) ^ ToolId;
            }
        }

        public static bool operator ==(HolderTool left, HolderTool right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HolderTool left, HolderTool right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((HolderTool) obj);
        }
    }

    public partial class MachineGroup : IEntity, IEquatable<MachineGroup>
    {
        #region IEquatable<MachineGroup> Members

        public bool Equals(MachineGroup other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name);
        }

        #endregion

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(MachineGroup left, MachineGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MachineGroup left, MachineGroup right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((MachineGroup) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Method : IEntity, IEquatable<Method>
    {
        #region IEquatable<Method> Members

        public bool Equals(Method other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Description, other.Description) && PartVersionId == other.PartVersionId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((Description != null ? Description.GetHashCode() : 0)*397) ^ PartVersionId;
            }
        }

        public static bool operator ==(Method left, Method right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Method left, Method right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Method) obj);
        }

        public override string ToString()
        {
            return Description;
        }
    }

    public partial class Operation : IEntity, IEquatable<Operation>
    {
        #region IEquatable<Operation> Members

        public bool Equals(Operation other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return MethodId == other.MethodId && Sequence == other.Sequence;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return (MethodId*397) ^ Sequence;
            }
        }

        public static bool operator ==(Operation left, Operation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Operation left, Operation right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Operation) obj);
        }

        public override string ToString()
        {
            return Description;
        }
    }

    public partial class OperationTool : IEntity, IEquatable<OperationTool>
    {
        #region IEquatable<OperationTool> Members

        public bool Equals(OperationTool other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return Position == other.Position && Offset == other.Offset && OperationId == other.OperationId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                int hashCode = Position;
                hashCode = (hashCode*397) ^ Offset;
                hashCode = (hashCode*397) ^ OperationId;
                return hashCode;
            }
        }

        public static bool operator ==(OperationTool left, OperationTool right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OperationTool left, OperationTool right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((OperationTool) obj);
        }
    }

    public partial class Part : IEntity, IEquatable<Part>
    {
        #region IEquatable<Part> Members

        public bool Equals(Part other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(DrawingNumber, other.DrawingNumber) && CustomerId == other.CustomerId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((DrawingNumber != null ? DrawingNumber.GetHashCode() : 0)*397) ^ CustomerId;
            }
        }

        public static bool operator ==(Part left, Part right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Part left, Part right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Part) obj);
        }

        public override string ToString()
        {
            return DrawingNumber;
        }
    }

    public partial class PartVersion : IEntity, IEquatable<PartVersion>
    {
        #region IEquatable<PartVersion> Members

        public bool Equals(PartVersion other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(VersionNumber, other.VersionNumber) && PartId == other.PartId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((VersionNumber != null ? VersionNumber.GetHashCode() : 0)*397) ^ PartId;
            }
        }

        public static bool operator ==(PartVersion left, PartVersion right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PartVersion left, PartVersion right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }

            var other = obj as PartVersion;

            if (other == null) {
                return false;
            }

            return Equals(other);
        }

        public override string ToString()
        {
            return VersionNumber;
        }
    }

    public partial class Tool : IEntity, IEquatable<Tool>
    {
        #region IEquatable<Tool> Members

        public bool Equals(Tool other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Description, other.Description) && ToolGroupId == other.ToolGroupId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((Description != null ? Description.GetHashCode() : 0)*397) ^ ToolGroupId;
            }
        }

        public static bool operator ==(Tool left, Tool right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tool left, Tool right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Tool) obj);
        }

        public override string ToString()
        {
            return Description;
        }
    }

    public partial class ToolGroup : IEntity, IEquatable<ToolGroup>
    {
        #region IEquatable<ToolGroup> Members

        public bool Equals(ToolGroup other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name) && ParentGroupId == other.ParentGroupId;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ ParentGroupId.GetHashCode();
            }
        }

        public static bool operator ==(ToolGroup left, ToolGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ToolGroup left, ToolGroup right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((ToolGroup) obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class TricornTool : IEntity, IEquatable<TricornTool>
    {
        #region IEquatable<TricornTool> Members

        public bool Equals(TricornTool other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return ToolId == other.ToolId && TricornReference == other.TricornReference;
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return (ToolId*397) ^ TricornReference;
            }
        }

        public static bool operator ==(TricornTool left, TricornTool right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TricornTool left, TricornTool right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((TricornTool) obj);
        }
    }
}