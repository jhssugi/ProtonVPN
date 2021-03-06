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

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ProtonVPN.Common.Configuration.Api.Handlers.TlsPinning;

namespace ProtonVPN.Core.Api.Handlers.TlsPinning
{
    internal class TlsPinningPolicy
    {
        public bool Valid(TlsPinnedDomain domain, X509Certificate certificate)
        {
            if (domain == null)
            {
                return true;
            }

            var hash = new PublicKeyInfoHash(certificate).Value();
            return domain.PublicKeyHashes.Contains(hash);
        }
    }
}
