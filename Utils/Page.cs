using System;
using System.Collections.Generic;
using System.Text;

namespace Tmall.Core.Utils
{
    public class Page<T>
    {
        public int NavigatePages { get; set; }

        // 总页数
        public int TotalPages { get; set; }

        // 第几页（基0）
        public int Number { get; set; }

        // 总共有多少条数据
        public long TotalElements { get; set; }

        // 一页最多多少条
        public int Size { get; set; }

        // 当前页有多少条数据 (与 size，不同的是，最后一页可能不满 size 个)
        public int NumberOfElements { get; set; }

        // 数据集合
        public List<T> Content { get; set; }

        // 是否有数据
        public bool HasContent { get; set; }

        // 是否是首页
        public bool First { get; set; }

        // 是否是末页
        public bool Last { get; set; }

        // 是否有下一页
        public bool HasNext { get; set; }

        // 是否有上一页
        public bool HasPrevious { get; set; }
    }
}
