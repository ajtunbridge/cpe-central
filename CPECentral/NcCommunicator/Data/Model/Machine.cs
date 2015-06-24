#region Using directives

using System;
using System.Drawing;

#endregion

namespace NcCommunicator.Data.Model
{
    public class Machine : IEquatable<Machine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Photo { get; set; }

        #region IEquatable<Machine> Members

        public bool Equals(Machine other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }

            string typeName = GetType().FullName;

            return Id == other.Id && string.Equals(typeName, other.GetType().FullName);
        }

        #endregion

        public override int GetHashCode()
        {
            unchecked {
                return (Id*397) ^ GetType().FullName.GetHashCode();
            }
        }

        public static bool operator ==(Machine left, Machine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Machine left, Machine right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Name;
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
            return Equals((Machine) obj);
        }
    }
}