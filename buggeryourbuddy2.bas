#include "fbgfx.bi"
#include "aulib.bi"
#include "crt.bi"

'define fbc -s gui

#define MINPLAYERS 4
#define MAXPLAYERS 10

#define nl 12

'12 high
'8 wide

using fb, auios

enum menus
    m_start
    m_getPlayerCount
    m_getPlayerNames
    m_game
    m_exitApp
end enum

type camera
    as integer x,y
    as integer speed = 15
end type

type player
    as zstring*13 sign
    as integer score
end type

type gameManager
    as integer playerCount
    as integer maxRounds
    as integer currentRound
    as integer selectedPlayer
    as integer ptr ask
    as boolean ptr got
    
    as player ptr pl
    
    as menus menu
    as string ans
    
    declare sub printStart()
    declare sub printgetPlayerCount()
    declare sub printgetPlayerNames()
    declare sub drawGame(cam as camera)
end type

sub gameManager.printStart()
    print("+--------------------+")
    print("|                    |")
    print("| Bugger Your Buddy! |")
    print("|                    |")
    print("+--------------------+")
    print("| 1. Start           |")
    print("|                    |")
    print("| 0. Exit            |")
    print("+--------------------+")
    print(" >                    ")
end sub

sub gameManager.printGetPlayerCount()
    print("+-----------------------------------+")
    print("| Enter number of players (4 to 10) |")
    print("+-----------------------------------+")
    print(" >                                   ")
    locate(4,4):print(this.ans)
end sub

sub gameManager.printGetPlayerNames()
    print("+-------------------------+")
    print("| Enter player names      |")
    print("+-------------------------+")
    for i as integer = 0 to this.playerCount-1
        locate(4+(i*2),1) :print("| Player   : ____________ |")
        locate(5+(i*2),1) :print("|                         |")
        locate(4+(i*2),10):print(i+1)
        locate(4+(i*2),14):print(this.pl[i].sign)
        if(this.selectedPlayer = i) then locate(4+(i*2),2):print(">")
    next i
    print("+-------------------------+")
end sub

sub gameManager.drawGame(cam as camera)
    dim as integer cl = 1 'Current line
    
    draw string(cam.x+8,cam.y+(nl*cl)),      "+----+" : cl+=1
    draw string(cam.x+8,cam.y+(nl*cl)),      "| Rnd|" : cl+=1
    draw string(cam.x+8,cam.y+(nl*cl)),      "+----+" : cl+=1
    for i as integer = 0 to maxRounds-1
        draw string(cam.x+8*3,cam.y+(nl*cl)),"" & maxRounds-i
        draw string(cam.x+8  ,cam.y+(nl*cl)),"|    |" : cl+=1
        draw string(cam.x+8  ,cam.y+(nl*cl)),"+----+" : cl+=1
    next i
    
    for i as integer = 0 to maxRounds-1
        draw string(cam.x+8*3,cam.y+(nl*cl)),"" & i+1
        draw string(cam.x+8  ,cam.y+(nl*cl)),"|    |" : cl+=1
        draw string(cam.x+8  ,cam.y+(nl*cl)),"+----+" : cl+=1
    next i
    
    for i as integer = 0 to playerCount-1
        draw string(cam.x+8*(19*i+8),cam.y+(nl*2)),"" & this.pl[i].sign
        draw string(cam.x+8*(19*i+6),cam.y+(nl*1)),"+--------------+---+"
        draw string(cam.x+8*(19*i+6),cam.y+(nl*2)),"|              |Ask|"
        draw string(cam.x+8*(19*i+6),cam.y+(nl*3)),"+--------------+---+"
        
        cl = 4
        for j as integer = 0 to this.maxRounds*2-1
            if(this.currentRound = j AND this.selectedPlayer = i) then
                draw string(cam.x+8*(19*i+22),cam.y+(nl*cl)),">" & this.ans
            else
                var idx = (j * this.playerCount) + i
                draw string(cam.x+8*(19*i+22),cam.y+(nl*cl)),"" & this.ask[idx]
            end if
            draw string(cam.x+8*(19*i+6),cam.y+(nl*cl)),  "|              |   |" : cl+=1
            draw string(cam.x+8*(19*i+6),cam.y+(nl*cl)),  "+--------------+---+" : cl+=1
        next j
    next i
end sub

dim as boolean runApp = true
dim as string k

dim shared as gameManager gm
dim shared as camera cam

dim shared as AuWindow wnd
wnd.set(800,600,,,,"Bugger Your Buddy!")
wnd.create()
color(rgb(0,0,0), rgb(255,255,255))
cls()

while(runApp)
    k = inkey()
    
    cls()
    
    select case gm.menu
    case m_start
        gm.printStart()
        
        select case k
        case "1"
            gm.menu = m_getPlayerCount
            exit select
        case "0", chr(27)
            gm.menu = m_exitApp
            exit select
        end select
        
        exit select
        
    case m_getPlayerCount
        gm.printGetPlayerCount()
        
        select case k
        case "0" to "9"
            gm.ans+=k
            exit select
            
        case chr(8)
            gm.ans = left(gm.ans,len(gm.ans)-1)
            exit select
            
        case chr(13)
            gm.playerCount = fix(val(gm.ans))
            if(gm.playerCount >= MINPLAYERS AND gm.playerCount <= MAXPLAYERS) then
                gm.menu = m_getPlayerNames
                gm.maxRounds = fix(52/gm.playerCount)
                if(gm.pl  <> 0) then delete[] gm.pl:gm.pl = 0
                if(gm.ask <> 0) then delete[] gm.ask:gm.ask = 0
                if(gm.got <> 0) then delete[] gm.got:gm.got = 0
                gm.pl = new player[gm.playerCount]
                gm.ask = new integer[gm.playerCount * gm.maxRounds*2]
                for y as integer = 0 to gm.maxRounds-1
                    for x as integer = 0 to gm.playerCount-1
                        var idx = (y*gm.playerCount)+x
                        gm.ask[idx] = 0
                    next x
                next y
                gm.got = new boolean[gm.playerCount * gm.maxRounds*2]
                
                printf("maxRounds: " & gm.maxRounds & !"\n")
                printf("playerCnt: " & gm.playerCount & !"\n")
                printf("total: " & gm.maxRounds * gm.playerCount & !"\n")
            end if
            gm.ans = ""
            exit select
            
        case chr(27)
            gm.menu = m_start
            exit select
        end select
        exit select
        
    case m_getPlayerNames
        gm.printGetPlayerNames()
        
        select case k
        case "a" to "z", "A" to "Z"
            if(len(gm.pl[gm.selectedPlayer].sign) < 12) then
                gm.pl[gm.selectedPlayer].sign+=k
            end if
            exit select
            
        case chr(8)
            var siLen = len(gm.pl[gm.selectedPlayer].sign)-1
            var siSi = gm.pl[gm.selectedPlayer].sign
            gm.pl[gm.selectedPlayer].sign = left(siSi,siLen)
            exit select
            
        case chr(13)
            if(gm.selectedPlayer = gm.playerCount-1) then
                gm.menu = m_game
                gm.selectedPlayer = 0
            else
                gm.selectedPlayer+=1
            end if
            exit select
            
        case chr(27)
            if(gm.selectedPlayer = 0) then
                gm.menu = m_getPlayerCount
            else
                gm.selectedPlayer-=1
            end if
            exit select
        end select
        exit select
        
    case m_game '---------------------------------------------------------------
        if(multikey(sc_lshift)) then
            if(multikey(sc_up))       then cam.y+=cam.speed*2
            if(multikey(sc_down))     then cam.y-=cam.speed*2
            if(multikey(sc_left))     then cam.x+=cam.speed*2
            if(multikey(sc_right))    then cam.x-=cam.speed*2
        else
            if(multikey(sc_up))       then cam.y+=cam.speed
            if(multikey(sc_down))     then cam.y-=cam.speed
            if(multikey(sc_left))     then cam.x+=cam.speed
            if(multikey(sc_right))    then cam.x-=cam.speed
        end if
        
        screenlock()
            cls()
            gm.drawGame(cam)
        screenUnlock()
        
        select case k
        case "0" to "9"
            if(len(gm.ans) < 2) then
                gm.ans+=k
            end if
            exit select
            
        case chr(8)
            gm.ans = left(gm.ans,len(gm.ans)-1)
            exit select
            
        case chr(13)
            if(len(gm.ans)) then
                var idx = (gm.currentRound * gm.playerCount) + gm.selectedPlayer
                gm.ask[idx] = fix(val(gm.ans))
                gm.selectedPlayer+=1
                gm.ans = ""
            end if
            
        case chr(27)
            gm.menu = m_start
        end select
        exit select
        
    case m_exitApp
        runApp = false
        exit select
    end select
    
    sleep(20,1)
wend
