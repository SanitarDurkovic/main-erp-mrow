﻿using Content.Server.GameTicking;
using Content.Server.Voting.Managers;
using Content.Shared._EE.CCVar;
using Content.Shared.GameTicking;
using Content.Shared.Voting;
using Robust.Server.Player;
using Robust.Shared.Configuration;

namespace Content.Server._EE.Autovote;

public sealed class AutoVoteSystem : EntitySystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;
    [Dependency] public readonly IVoteManager _voteManager = default!;
    [Dependency] public readonly IPlayerManager _playerManager = default!;

    public bool _shouldVoteNextJoin = false;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RoundRestartCleanupEvent>(OnReturnedToLobby);
        SubscribeLocalEvent<PlayerJoinedLobbyEvent>(OnPlayerJoinedLobby);
    }

    public void OnReturnedToLobby(RoundRestartCleanupEvent ev) => CallAutovote();

    public void OnPlayerJoinedLobby(PlayerJoinedLobbyEvent ev)
    {
        if (!_shouldVoteNextJoin)
            return;

        CallAutovote();
        _shouldVoteNextJoin = false;
    }

    private void CallAutovote()
    {
        if (!_cfg.GetCVar(EECCVars.AutoVoteEnabled))
            return;

        if (_playerManager.PlayerCount == 0)
        {
            _shouldVoteNextJoin = true;
            return;
        }

        if (_cfg.GetCVar(EECCVars.MapAutoVoteEnabled))
            _voteManager.CreateStandardVote(null, StandardVoteType.Map);
        if (_cfg.GetCVar(EECCVars.PresetAutoVoteEnabled))
            _voteManager.CreateStandardVote(null, StandardVoteType.Preset);
    }
}
