using System;
using System.Collections.Generic;

namespace TradingPlatform.ClientService.Contracts
{
	public class ItemPaginationViewModel
	{
		public bool EnablePrevNextButtons { get; private set; }
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PagesOnPage {  get; private set; }
		public int MinPage {  get; private set; }
		public int MaxPage { get; private set; }
		public string CurrentSort { get; set; }
		public string CurrentFilter { get; set; }
		public ItemPaginationViewModel(bool enablePrevNextButtons, int count, int pageNumber, int pageSize,int pagesOnPage)
		{
			EnablePrevNextButtons = enablePrevNextButtons;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			PagesOnPage = pagesOnPage;

			MinPage = CurrentPage - PagesOnPage / 2;
			if (MinPage < 1)
			{
				MinPage = 1;
			}
			MaxPage= MinPage + PagesOnPage;
			if (MaxPage > TotalPages+1)
			{
				MaxPage = TotalPages+1;
			}
		}
		public int GetPreviousPage() => CurrentPage - 1;
		public bool HasPreviousPage() => CurrentPage > 1;
		public int GetNextPage() => CurrentPage + 1;
		public bool HasNextPage() => CurrentPage < TotalPages;
	}
}