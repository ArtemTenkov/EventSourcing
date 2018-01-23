﻿using SharedKernel;
using SharedKernel.Domain;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Balance
{
    public class BalanceState : StateBase
    {
        public Guid UserGuid { get; private set; }
        public Amount Amount { get; private set; }
        public List<Transaction> Transactions { get; private set;    }
        public override void Modify(object @event) =>
            RedirectToWhen.InvokeEventOptional(this, @event);
    }
}
