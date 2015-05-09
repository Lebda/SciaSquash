using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SciaSquash.Model.Abstract;

namespace SciaSquash.Model.Concrete
{
    public class ResultsCalculator : IResultsCalculator
    {
        public ResultsCalculator(
            IPlayerReposiroty playerRepo,
            IMatchRepository matchRepo,
            IResolver<IScore4Rival> score4RivalResolver,
            IResolver<IPlayerResult> playerResultResolver)
        {
            m_playerRepo = playerRepo;
            m_matchRepo = matchRepo;
            m_resolver = playerResultResolver;
            m_score4RivalResolver = score4RivalResolver;

            PreparePlayers();
        }
        
        #region MEMBERS
        readonly IPlayerReposiroty m_playerRepo;
        readonly IMatchRepository m_matchRepo;
        readonly IResolver<IPlayerResult> m_resolver;
        readonly IResolver<IScore4Rival> m_score4RivalResolver;
        #endregion
        
        #region PROPERTIES
        public IPlayerResult Leader 
        { 
            get { return Items.First(); }
        }
        public ICollection<IPlayerResult> Items { get; set; }
        #endregion
        
        #region METHODS
        private void PreparePlayers()
        {
            var queryPlayers = m_playerRepo.DataQueryable()
                                           .Include(i => i.PlayerAsFirst)
                                           .Include(i => i.PlayerAsSecond);
            List<IPlayerResult> playersResults = new List<IPlayerResult>();
            foreach (var item in queryPlayers)
            {
                IPlayerResult playerResult = m_resolver.Resolve();
                playerResult.Player = item;
                playersResults.Add(playerResult);
            }
            foreach (var itemResult in playersResults)
            {
                foreach (var rival in queryPlayers)
                {
                    if (itemResult.Player.PlayerID == rival.PlayerID)
                    {
                        continue;
                    }
                    itemResult.RivalScore.Add(rival.PlayerID, PrepareRivalScore(itemResult.Player.PlayerID, rival.PlayerID));
                }
            }
            Items = playersResults.OrderByDescending(item => item.Points).OrderByDescending(item => (item.ScrorePlus - item.ScoreMinus)).ToList();
        }
        private IScore4Rival PrepareRivalScore(int playerID, int rivalID)
        {
            IScore4Rival retVal = m_score4RivalResolver.Resolve();
            var queryMatches = m_matchRepo.DataQueryable()
                .Where(item => (item.FirstPlayerID == playerID && item.SecondPlayerID == rivalID) || (item.FirstPlayerID == rivalID && item.SecondPlayerID == playerID));
            foreach (var match in queryMatches)
            {
                if (match.FirstPlayerID == playerID)
                {
                    retVal.ScorePlus = retVal.ScorePlus + match.ScorePlayerFirst;
                    retVal.ScoreMinus = retVal.ScoreMinus + match.ScorePlayerSecond;
                }
                else
                {
                    retVal.ScorePlus = retVal.ScorePlus + match.ScorePlayerSecond;
                    retVal.ScoreMinus = retVal.ScoreMinus + match.ScorePlayerFirst;
                }
            }

            return retVal;
        }
        #endregion
    }
}