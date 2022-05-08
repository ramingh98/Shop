﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Enums;
using Common.Domain;

namespace BookShop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string description, bool isFinally, WalletType type)
        {
            Price = price;
            Description = description;
            IsFinally = isFinally;
            Type = type;
            if (isFinally == true)
            {
                FinallyDate = DateTime.Now;
            }
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }
        public WalletType Type { get; private set; }

        public void Finally(string refCode)
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            Description += $"کد پیگیری : {refCode}";
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }
    }
}
