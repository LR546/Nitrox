﻿using System.Collections.Generic;
using UnityEngine;

namespace NitroxClient.GameLogic.ItemDropActions
{
    public abstract class ItemDropAction
    {
        public abstract void ProcessDroppedItem(GameObject gameObject);

        private static readonly Dictionary<TechType, ItemDropAction> dropActionsByTechType = new Dictionary<TechType, ItemDropAction>()
        {
            { TechType.Constructor, new ConstructorDropAction() }
        };

        public static ItemDropAction FromTechType(TechType techType)
        {
            if (dropActionsByTechType.TryGetValue(techType, out ItemDropAction itemDropAction))
            {
                return itemDropAction;
            }

            return new NoOpDropAction();
        }
    }
}
