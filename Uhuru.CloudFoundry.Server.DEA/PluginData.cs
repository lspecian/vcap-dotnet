﻿// -----------------------------------------------------------------------
// <copyright file="PluginData.cs" company="Uhuru Software">
// Copyright (c) 2011 Uhuru Software, Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace Uhuru.CloudFoundry.DEA
{
    /// <summary>
    /// The basic data related to a plugin
    /// </summary>
    internal struct PluginData
    {
        /// <summary>
        /// the name of the class implementing the IAgentPlugin interface
        /// </summary>
        public string ClassName;

        /// <summary>
        /// the path of the library containing the class that implements the IAgentPlugin interface
        /// </summary>
        public string FilePath;
    }
}