using System;
using System.Collections.Generic;
using System.Text;

namespace Tmall.Core.Utils
{
    public class PageUtil<T>
    {
        /// <summary>
        /// 计算分页
        /// </summary>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <param name="navigatePages"></param>
        /// <param name="pageList">总数据集</param>
        /// <param name="allList">分页数据集</param>
        /// <returns></returns>
        public static Page<T> CalcPage(int start, int size, int navigatePages, List<T> pageList, List<T> allList) {
            int allListCount = allList.Count; // 总的数据长度
            int pageListCount = pageList.Count; // 分页的数据长度
            int totalPages = allListCount / size + 1; // 总页数
            bool first = start == 0 ? true : false; // 是否是首页
            bool last = start == totalPages ? true : false; // 是否是末页
            Page<T> page = new Page<T>
            {
                NavigatePages = navigatePages,
                // 总页数
                TotalPages = totalPages,
                // 第几页（基0）
                Number = start,
                // 总共有多少条数据
                TotalElements = allListCount,
                // 一页最多多少条
                Size = size,
                // 当前页有多少条数据 (与 size，不同的是，最后一页可能不满 size 个)
                NumberOfElements = pageListCount,
                // 数据集合
                Content = pageList,
                // 是否有数据
                HasContent = pageListCount == 0 ? false : true,
                // 是否是首页
                First = first,
                // 是否是末页
                Last = last,
                // 是否有下一页
                HasNext = !last,
                // 是否有上一页
                HasPrevious = !first
            };
            return page;
        }
    }
}
