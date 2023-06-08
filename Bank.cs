﻿using System;
using System.Collections.Generic;

/*
Give the Bank class the following properties:
*/

public class Bank {

    //An integer property for CashOnHand
    public int CashOnHand { get; set; }
    //An integer property for AlarmScore
    public int AlarmScore { get; set; }
    //An integer property for VaultScore
    public int VaultScore { get; set; }
    //An integer property for SecurityGuardScore
    public int SecurityGuardScore { get; set; }

    //A computed boolean property called IsSecure. If all the scores are less than or equal to 0, 
    //this should be false. If any of the scores are above 0, this should be true
    public bool IsSecure() {
        if (AlarmScore <= 0 || VaultScore <= 0 || SecurityGuardScore <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}