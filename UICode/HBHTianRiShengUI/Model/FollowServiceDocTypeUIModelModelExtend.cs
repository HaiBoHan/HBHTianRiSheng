#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace FollowServiceDocTypeUIModel
{	public partial class FollowServiceDocTypeUIModelModel 
	{
        //初始化UIMODEL之后的方法
        public override  void AfterInitModel()
        {
            //this.Views[0].Fields[0].DefaultValue = thsi.co
            this.FollowServiceDocType.FieldDocHeaderSequence.DefaultValue = (int)UFIDA.U9.Base.Doc.DocHeaderSequenceStyleEnumData.Artificial;

            //this.FollowServiceDocType.PropertyEntityFullName.DefaultValue = this.FollowServiceDocType.EntityFullName;
            //this.FollowServiceDocType.PropertyEntityFullName.Value = this.FollowServiceDocType.EntityFullName;
        }
        
        //UIModel提交保存之前的校验操作.
        public override void OnValidate()
        {
        		base.OnValidate() ;
            OnValidate_DefualtImpl();
            //your coustom code ...
        }
	}
}