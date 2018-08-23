﻿using ESI.NET.Models.FactionWarfare;
using ESI.NET.Models.SSO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static ESI.NET.EsiRequest;

namespace ESI.NET.Logic
{
    public class FactionWarfareLogic
    {
        private HttpClient _client;
        private ESIConfig _config;
        private AuthorizedCharacterData _data;
        private int corporation_id, character_id;

        public FactionWarfareLogic(HttpClient client, ESIConfig config, AuthorizedCharacterData data = null)
        {
            _client = client;
            _config = config;
            _data = data;

            if (data != null)
            {
                corporation_id = data.CorporationID;
                character_id = data.CharacterID;
            }
        }

        /// <summary>
        /// /fw/wars/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<List<War>>> List()
            => await Execute<List<War>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/wars/");

        /// <summary>
        /// /fw/stats/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<List<Stat>>> Stats()
            => await Execute<List<Stat>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/stats/");

        /// <summary>
        /// /fw/systems/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<List<FactionWarfareSystem>>> Systems()
            => await Execute<List<FactionWarfareSystem>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/systems/");

        /// <summary>
        /// fw/leaderboards/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<Leaderboards<FactionTotal>>> Leaderboads()
            => await Execute<Leaderboards<FactionTotal>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/leaderboards/");

        /// <summary>
        /// /fw/leaderboards/corporations/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<Leaderboards<CorporationTotal>>> LeaderboardsForCorporations()
            => await Execute<Leaderboards<CorporationTotal>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/leaderboards/corporations/");

        /// <summary>
        /// /fw/leaderboards/characters/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<Leaderboards<CharacterTotal>>> LeaderboardsForCharacters()
            => await Execute<Leaderboards<CharacterTotal>>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/fw/leaderboards/characters/");

        /// <summary>
        /// /corporations/{corporation_id}/fw/stats/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<Stat>> StatsForCorporation()
            => await Execute<Stat>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/corporations/{corporation_id}/fw/stats/", token: _data.Token);

        /// <summary>
        /// /characters/{character_id}/fw/stats/
        /// </summary>
        /// <returns></returns>
        public async Task<EsiResponse<Stat>> StatsForCharacter()
            => await Execute<Stat>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/characters/{character_id}/fw/stats/", token: _data.Token);
    }
}