/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading;
using Dolittle.DependencyInversion;
using Dolittle.Lifecycle;
using Read;
using Read.Applications;
using Read.Tenants;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthContextBindings : ICanProvideBindings
    {
        static AsyncLocal<AuthContext> _authContext = new AsyncLocal<AuthContext>();

        internal static AuthContext AuthContext
        { 
            get { return _authContext.Value; }
            set { _authContext.Value = value; }
        }

        [Singleton]
        class AuthContextProxy : IAuthContext
        {
            public Tenant Tenant => _authContext.Value.Tenant;

            public Application Application => _authContext.Value.Application;
        }

        /// <inheritdoc/>
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<IAuthContext>().To<AuthContextProxy>();
        }
    }
}