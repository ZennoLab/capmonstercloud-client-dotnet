using System;
using System.Collections.Generic;
using System.Text;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Response for grid-like tasks
    /// </summary>
    public class GridComplexImageTaskResponse
    {
        /// <summary>
        /// Collection with answers. Click on images with 'true'
        /// </summary>
        /// <example>
        /// [false,true,false,true,false,false,true,false,false]
        /// </example>
        public ICollection<bool> Answer { get; set; }
    }
}
