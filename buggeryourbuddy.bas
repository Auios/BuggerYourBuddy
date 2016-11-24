'Bugger your buddy

#include "fbgfx.bi"
#include "aulib.bi"
#include "mysoftFont.bi"

#define MINPLAYERS 4
#define MAXPLAYERS 26

using fb, auios

declare sub wipe()
declare sub centerPrint(height as integer,sz as integer, text as string)

dim as boolean isValid
dim as string ans

dim shared as AuWindow wnd

wnd.set()
wnd.create()

isValid = false
do
    wipe()
    centerPrint(wnd.h/2, 25, "How many players?")
    centerprint(wnd.h/2, 25, "(" & MINPLAYERS & " - " & MAXPLAYERS & ")")
    
    do
        
    loop until k = 
    
    if(val(ans) >= MINPLAYERS and val(ans) <= MAXPLAYERS) then
        isValid = true
    end if
loop until isValid

end(wnd.destroy())

'=====================

sub wipe()
    cls()
    line(0,0)-(wnd.w,wnd.h),rgb(255,255,255),bf
end sub

sub centerPrint(height as integer,sz as integer, text as string)
    var CM="Cambria"
    drawfont(,(wnd.w/2)-(len(text)*8), height, text, CM, sz, rgb(0,0,0), 0)
    'draw string(wnd.w/2, height), text
end sub