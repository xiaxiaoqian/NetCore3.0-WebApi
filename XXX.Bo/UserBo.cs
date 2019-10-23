using System.Linq;

namespace XXX.Bo
{
    public class UserBo
    {
        public static XXXContext db = new XXXContext();
        /// <summary>
        /// 增加一个用户数据
        /// </summary>
        /// <param name="model"></param>
        public static Models.User.AddUserR AddUser(Models.User.AddUserP model)
        {
            var r = new Models.User.AddUserR();
            if (Common.SignMgr.ParamVerify(model))
            {
                Models.XXXEntities.User userSearch = (from u in db.User where u.Phone == model.phone select u).FirstOrDefault();
                if (userSearch == null)
                {
                    Models.XXXEntities.User user = new Models.XXXEntities.User();
                    user.Phone = model.phone;
                    user.Password = model.password;
                    user.NickName = model.nickName;
                    user.State = model.state;
                    db.User.Add(user);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        r.code = 1;
                        r.message = "数据插入成功";
                    }
                    else
                    {
                        r.code = 0;
                        r.message = "数据插入成功";
                    }
                }
                else
                {
                    r.code = 0;
                    r.message = "手机号已经存在";
                }
            }
            else
            {
                r.code = 0;
                r.message = "签名失败";
            }
            return r;
        }
    }
}
