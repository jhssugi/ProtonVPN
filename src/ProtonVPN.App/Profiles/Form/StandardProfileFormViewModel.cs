/*
 * Copyright (c) 2020 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using ProtonVPN.Core.Modals;
using ProtonVPN.Core.Profiles;
using ProtonVPN.Core.Servers;
using ProtonVPN.Core.Settings;
using ProtonVPN.Profiles.Servers;

namespace ProtonVPN.Profiles.Form
{
    public class StandardProfileFormViewModel : BaseCountryServerProfileFormViewModel
    {
        public StandardProfileFormViewModel(
            Common.Configuration.Config appConfig,
            ColorProvider colorProvider,
            IUserStorage userStorage,
            ServerManager serverManager,
            ProfileManager profileManager,
            IModals modals,
            IDialogs dialogs) : base(appConfig, colorProvider, userStorage, profileManager, dialogs, modals, serverManager)
        {
        }

        protected override Features GetFeatures()
        {
            return Features.None;
        }

        protected override List<IServerViewModel> GetServersByCountry(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                return new List<IServerViewModel>();

            return base.GetServersByCountry(countryCode);
        }
    }
}
