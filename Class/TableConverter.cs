using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBOperation.Resource;
using System.Windows;

namespace DBOperation.Class
{
    public  static class TableConverter
    {
        public static tb_Base_Traj TrajTbConverter(List<TrajBean> trajLst)
        {
            var tb_traj = new tb_Base_Traj();
            tb_traj.TrajCount = trajLst.Count;
            var originp = trajLst[0];
            tb_traj.OrgHeight = originp.TrajHeight;
            tb_traj.OrgLat = originp.TrajLat;
            tb_traj.OrgLong = originp.TrajLong;
            tb_traj.OrgPitAng = originp.PitchAng;
            tb_traj.OrgRolllAng = originp.ScrollAng;
            tb_traj.OrgYawAng = originp.YawAng;
            if (trajLst.Count > 1)
            {
                var finalPostion = trajLst.Last();
                tb_traj.EndHeight = finalPostion.TrajHeight;
                tb_traj.EndLat = finalPostion.TrajLat;
                tb_traj.EndLong = finalPostion.TrajLong;
            }
            else
            {
                tb_traj.EndHeight = 0;
                tb_traj.EndLat = 0;
                tb_traj.EndLong = 0;
            }
            return tb_traj;
        }
        /// <summary>
        /// path未添加 在主程序添加
        /// </summary>
        /// <param name="ipImgLst"></param>
        /// <returns></returns>
        public static tb_Base_Image ImgTbConverter(List<InputImgInfo> ipImgLst)
        {
            var tb_img = new tb_Base_Image();
            var recordInfo = Application.Current.TryFindResource("recordInfoBean") as RecordInfoBean;
            tb_img.ImgCount = ipImgLst.Count;
            tb_img.ImgRemark = recordInfo.Remark;
            tb_img.ImgType = recordInfo.Type;
            tb_img.ImgReSource = recordInfo.WaveLength;
            tb_img.ImgResolutionHeight = ipImgLst[0].resolutionY;
            tb_img.ImgResolutionWidth = ipImgLst[0].resolutionX;
            return tb_img;
        }
        public static tb_Base_Interference IFTbConverter(List<IFBean> _IfBeanLst)
        {
            var tb_if = new tb_Base_Interference();
            var _ifBean=_IfBeanLst.First();
            tb_if.IFType = _ifBean.IFSource;
            tb_if.IsShade = (short)(_ifBean.IFShade == true ? 1 : 0);
            tb_if.IFLocation_x = _ifBean.IFLong;
            tb_if.IFLocation_y = _ifBean.IFLat;

            return tb_if;
        }
        public static tb_Base_Main MainTbConverter()
        {
            var tb_main = new tb_Base_Main();
            var recordInfo = Application.Current.TryFindResource("recordInfoBean") as RecordInfoBean;
            tb_main.Aera = recordInfo.Area;
            tb_main.KeyWords = recordInfo.KeyWords;
            tb_main.UpdateTime = DateTime.Now.ToString();
           // tb_main.IFType = recordInfo.IFType;
            return tb_main;
        }
    }
}
