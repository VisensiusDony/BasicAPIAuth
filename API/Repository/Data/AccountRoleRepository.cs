using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, int>
    {
        private readonly MyContext myContext1;
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext1 = myContext;
        }
    }
}
