# Runewords

Runewords is non-interactive CLI App, that can help to lookup for specific or filter runewords from Diablo 2 Zy-El Mod. All runewords are taken from official ModGuide.pdf.
## Manual
### Commands
```
runes help
runes 1.0.0
Copyright (C) 2021 runes

  runes      Displays existing runes.

  words      Displays existing runewords.

  shorts     Displays existing shortcuts.

  classes    Displays existing classes.

  help       Display more information on a specific command.

  version    Display version information.
```
### *runes* command
Displays existing in the game runes and their levels.
```
runes runes --help
runes 1.0.0
Copyright (C) 2021 runes

  -l, --lvl     Only display runes with specified level.

  -r, --rune    Only display specific rune.

  --help        Display this help screen.

  --version     Display version information.
```
### *words* command
Displays existing in the game runewords and their details.
```
runes words --help
runes 1.0.0
Copyright (C) 2021 runes

  -l, --lvl           Only display runewords for specified level. If set, options [max-level] and [min-level] are ignored.

  -c, --class         Only display runewords for specified class.

  -o, --order         Apply ordering. Values: [class] - order by class, [level] - order by level. Orders by level by default.

  -d, --desc          Set descending order.

  -i, --item          Only display runewords for specified item.

  -r, --rune          Only display runewords which contain specified rune.

  -s, --sockets       Only display runewords for specified amount of sockets.

  --min-level         Only display runewords which level is greater than or equal to specified.

  --max-level         Only display runewords which level is less than or equal to specified.

  --skill-bonus       Only display runewords with skill bonus for all classes.

  --no-skill-bonus    Only display runewords with no skill bonus for all classes.

  --charges           Only display runewords with charges attribute.

  --no-charges        Only display runewords with no charges attribute.

  --help              Display this help screen.

  --version           Display version information.
```
### *shorts* command
Displays used in the app shortcuts for applicable items.
```
runes shorts --help
runes 1.0.0
Copyright (C) 2021 runes

  -s, --short    Only display items which contain specified value.

  --help         Display this help screen.

  --version      Display version information.
```
### *classes* command
Displays existing in the game classes of characters and their shortcuts, used in the app.
```
runes classes --help
runes 1.0.0
Copyright (C) 2021 runes

  --help       Display this help screen.

  --version    Display version information.
```
## Examples
```
runes words -l 45 -c b
```
Displays runewords for 45th level and for Barbarian class. Output:
```
Runewords:

        ------------------------------------------------------------------------------------------------------------------------------------------------
        ph                                    45              B                                                                      Ral(25)-Sol(45)
        ------------------------------------------------------------------------------------------------------------------------------------------------
```
```
runes words -i xb --max-level 40
```
Displays runewords which level is greater than or equal to 40 and which can be applied upon xb (Crossbow) item. Output:
```
Runewords:

        ------------------------------------------------------------------------------------------------------------------------------------------------
        xb                                    20              P                                                                      Ith(15)-Tal(20)
        ------------------------------------------------------------------------------------------------------------------------------------------------
        kn,xb,cq                              35            Any                                                                      Thul(35)-Ith(15)
        ------------------------------------------------------------------------------------------------------------------------------------------------
        xb                                    35              P                                                                      Ral(25)-Thul(35)
        ------------------------------------------------------------------------------------------------------------------------------------------------
```