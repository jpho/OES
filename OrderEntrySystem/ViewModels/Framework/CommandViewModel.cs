﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class representing a view model for commands.
    /// </summary>
    public class CommandViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CommandViewModel class.
        /// </summary>
        /// <param name="displayName">The name of the command.</param>
        /// <param name="command">The logic of the command.</param>
        public CommandViewModel(string displayName, ICommand command)
            : this(displayName, command, null, false, false)
        {
        }

        public CommandViewModel(string displayName, ICommand command, bool isDefault, bool isCancel)
            : this(displayName, command, null, isDefault, isCancel)
        {
        }

        public CommandViewModel(string displayName, ICommand command, string groupName, bool isDefault, bool isCancel)
            : base(displayName)
        {
            if (command == null)
            {
                throw new Exception("Command was null.");
            }

            this.Command = command;
            this.GroupName = groupName;
            this.IsCancel = isCancel;
            this.IsDefault = isDefault;
        }

        /// <summary>
        /// Gets the command to be viewed.
        /// </summary>
        public ICommand Command { get; private set; }

        public string GroupName { get; private set; }

        public bool IsCancel { get; private set; }

        public bool IsDefault { get; private set; }
    }
}