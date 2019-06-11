using System.Collections.Generic;

namespace Tmall.Core.Utils
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageNavigator<T>
    {
        // 分页的时候 ,如果总页数比较多，那么显示出来的分页超链一个有几个。 
        // 比如如果分页出来的超链是这样的： [8,9,10,11,12], 那么 navigatePages 就是5
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

        // 分页的时候 ,如果总页数比较多，那么显示出来的分页超链一个有几个。 
        // 比如如果分页出来的超链是这样的： [8,9,10,11,12]，那么 navigatepageNums 就是这个数组：[8,9,10,11,12]，这样便于前端展示
        public int[] NavigatepageNums { get; set; }

        public PageNavigator(Page<T> page)
        {
            NavigatePages = page.NavigatePages;
            TotalPages = page.TotalPages;
            Number = page.Number;
            TotalElements = page.TotalElements;
            Size = page.Size;
            NumberOfElements = page.NumberOfElements;
            Content = page.Content;
            HasContent = page.HasContent;
            First = page.First;
            Last = page.Last;
            HasNext = page.HasNext;
            HasPrevious = page.HasPrevious;
            CalcNavigatepageNums();
        }

        /// <summary>
        /// 计算分页的数值
        /// </summary>
        private void CalcNavigatepageNums()
        {
            int[] navigatepageNums;
            int totalPages = TotalPages;
            int num = Number;

            // 当总页数小于或等于导航页码数时
            if (totalPages <= NavigatePages)
            {
                navigatepageNums = new int[totalPages];
                for (int i = 0; i < totalPages; i++)
                {
                    navigatepageNums[i] = i + 1;
                }
            }
            else
            { 
                // 当总页数大于导航页码时
                navigatepageNums = new int[NavigatePages];
                int startNum = num - NavigatePages / 2;
                int endNum = num + NavigatePages / 2;

                if (startNum < 1)
                {
                    startNum = 1;
                    // 最前navigatePages页
                    for (int i = 0; i < NavigatePages; i++)
                    {
                        navigatepageNums[i] = startNum++;
                    }
                }
                else if (endNum > totalPages)
                {
                    endNum = totalPages;
                    // 最后navigatePages页
                    for (int i = NavigatePages - 1; i >= 0; i++)
                    {
                        navigatepageNums[i] = endNum--;
                    }
                }
                else
                {
                    // 所有中间页
                    for (int i = 0; i < NavigatePages; i++)
                    {
                        navigatepageNums[i] = startNum++;
                    }
                }
            }
            this.NavigatepageNums = navigatepageNums;
        }
    }
}
