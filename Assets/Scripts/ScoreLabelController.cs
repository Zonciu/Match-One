﻿using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour {

    Text _label;

    void Awake() {
        _label = GetComponent<Text>();
    }

    void Start() {
        var pool = Contexts.sharedInstance.gameSession;

        pool.GetGroup(GameSessionMatcher.Score).OnEntityAdded +=
            (group, entity, index, component) => updateScore(entity.score.value);

        updateScore(pool.score.value);
    }

    void updateScore(int score) {
        _label.text = "Score " + score;
    }
}
