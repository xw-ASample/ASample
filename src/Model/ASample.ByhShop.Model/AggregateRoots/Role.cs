using ASmaple.Domain.Models;


namespace ASample.ByhShop.Model
{
    public class Role:AggregateRoot
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
