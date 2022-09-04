﻿using System;

namespace SalesWeb.ASPNETCORE.Service.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
