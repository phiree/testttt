using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDijieshe
    {

        void Add();

        void Delete();

        void Modify();

        IList<Model.DJ_DijiesheInfo> GetDJS8All();

        IList<Model.DJ_DijiesheInfo> GetDJS8name();

        IList<Model.DJ_DijiesheInfo> GetDJS8area(int areaid);

        IList<Model.DJ_DijiesheInfo> GetDJS8type(string type);

        IList<Model.DJ_DijiesheInfo> GetDJS8name(string name);

        IList<Model.DJ_DijiesheInfo> GetDJS8Muti(int areaid, string type, string namelike);
    }
}
