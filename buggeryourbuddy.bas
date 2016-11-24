'Bugger your buddy

#include "fbgfx.bi"
#include "aulib.bi"

#define fbc -s gui

#define MINPLAYERS 4
#define MAXPLAYERS 26

enum menus
    m_enterPlayerCount
    m_enterPlayerNames
end enum

type player
    as zstring*13 sign
    as integer score
end type

type gameManager
    as integer playerCount = -1
    as integer maxRounds = 0
    as integer round = 0
    as menus menu
    as player ptr pl
    
    declare function enterPlayerCount() as boolean
    declare sub setup(usrIn as integer)
    declare sub printNames()
    declare sub displayPlayers()
    declare sub enterPlayerNames()
    declare sub displayScore()
end type

function gameManager.enterPlayerCount() as boolean
    dim as string ans
    dim as boolean isValid = false
    cls()
    
    print("+-------------------+")
    print("| How many players? |")
    print("|                   |")
    print("|                   |")
    print("+===================+")
    print("|                   |")
    print("+-------------------+")
    
    locate(3,3)    :print("(" & MINPLAYERS & " - " & MAXPLAYERS & ")")
    locate(6,3)    :input "> ", ans
    
    var usrIn = fix(val(ans))
    if(usrIn >= MINPLAYERS and usrIn <= MAXPLAYERS) then
        isValid = true
        this.menu = m_enterPlayerNames
        this.setup(usrIn)
    end if
end function

sub gameManager.setup(usrIn as integer)
    this.playerCount = usrIn
    this.maxRounds = 52/this.playerCount
    this.pl = new player[usrIn]
end sub

sub gameManager.printNames()
    for i as integer = 0 to this.playerCount-1
        print(i+1 & ": " & this.pl[i].sign & ", " & this.pl[i].score)
    next i
end sub

sub gameManager.enterPlayerNames()
    print("+-----------------------+")
    print("| Enter player names    |")
    print("+=======================+")
    
    for i as integer = 0 to this.playerCount-1
        locate(4+(i*3),1):print("| Player:               |")
        locate(5+(i*3),1):print("| Name:                 |")
        locate(6+(i*3),1):print("+-----------------------+")
        
        locate(4+(i*3),11):print(i+1)
    next i
    
    for i as integer = 0 to this.playerCount-1
        locate(5+(i*3),9):input "",this.pl[i].sign
        
        if(this.pl[i].sign = "") then
            this.menu = m_enterPlayerCount
            exit for
        end if
    next i
end sub

sub gameManager.displayPlayers()
    locate(2,51):   print("+-------------------+-------+")
    locate(3,51):   print("| No | Player       | Score |")
    locate(4,51):   print("+====+==============+=======+")
    for i as integer = 0 to this.playerCount-1
        locate(5+(i*2),51): print("|    |              |       |")
        locate(6+(i*2),51): print("+----+--------------+-------+")
        
        locate(5+(i*2),53): print(i+1)
        locate(5+(i*2),58): print(this.pl[i].sign)
        locate(5+(i*2),73): print(this.pl[i].score)
    next i
end sub

sub gameManager.displayScore()
    locate(1,1):print("+---------------------------+")
    locate(1,1):print("|                           |")
    locate(1,1):print("|                           |")
    locate(1,1):print("+---------------------------+")
end sub

dim as gameManager gm

using fb, auios

dim shared as AuWindow wnd

wnd.set(640,480,,,,"Bugger Your Buddy!")
wnd.create()

color(rgb(0,0,0), rgb(255,255,255))

do
    
    select case gm.menu
    case m_enterPlayerCount
        gm.enterPlayerCount()
    case m_enterPlayerNames
        gm.enterPlayerNames()
    end select
    
loop until 

cls()
gm.enterPlayerNames()
gm.displayPlayers()

sleep()

cls()


end(wnd.destroy())