#region Using directives

using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo>
    {
        public PhotoRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(PartVersion partVersion, byte[] photoBytes)
        {
            string address = string.Format("PartVersion:{0}", partVersion.Id);

            Photo record = GetPhotoByAddress(address);

            if (record == null) {
                record = new Photo {
                    Address = address,
                    Data = photoBytes
                };

                Add(record);
            }
            else {
                record.Data = photoBytes;

                Update(record);
            }
        }

        public byte[] GetByPartVersion(PartVersion partVersion)
        {
            string address = string.Format("PartVersion:{0}", partVersion.Id);

            Photo entity = GetSet().SingleOrDefault(p => p.Address == address);

            return entity == null ? null : entity.Data;
        }

        public void Delete(PartVersion partVersion)
        {
            string address = string.Format("PartVersion:{0}", partVersion.Id);

            var record = GetPhotoByAddress(address);

            Delete(record);
        }

        private Photo GetPhotoByAddress(string address)
        {
            return GetSet().SingleOrDefault(p => p.Address == address);
        }
    }
}