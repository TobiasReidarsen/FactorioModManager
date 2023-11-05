# FactorioModManagerReal

A tool to manage mods and modpacks for the video game factorio.

## Planned features
	- Downloading mods from the Factorio website directly from the mod manager
	- Easy to turn on and off mods
	- Mod packs can contain mutiple other mod packs, creating super mod packs
	- A simple CLI to let you easily create and handle mod packs
		- A mod pack is a group of mods that is defined by the user to belong together.
		EXAMPLE:
				Pseudo vim keybindings
				:m/mp <name> to search by name. m for search by mod, mp for mod pack
				:m/mp <name> on, to set a mod or mod pack to active, off, to turn off 	
				:m/mp SELECT <column>, to filter by column. :m SELECT Active shows all active mods
				:m/mp SELECT Active show BOTH all active mod packs and mods
				
				Mod Pack(s) Used: [ Mods I always use | Industry Mods ]
				
				Mods downloaded: 7 | Active Packs: 2
				Active Mods:     5 | Nr. Packs:    2
				----------------------------------------------------------------------------------------------------
				Mods			   | Active |	Mod_Packs			    | Pack_Contents	    | Amount_Mods | Active |
				-------------------|--------|---------------------------|-------------------|-------------|--------|
				Space Exploration  |  True  | Industry Mods			    | Bob's Inserters   | 3			  |	True   |
				-------------------|--------|						    |                   |             |		   |
				Bob's Inserters	   |  True  |						    | Pyadon			|			  |		   |
				-------------------|--------|						    |                   |             |		   |
				Angel's Industry   |  False |						    | Space Exploration |			  |		   |
				-------------------|--------|                           |                   |             |		   |
				Pyadon			   |  True  |---------------------------|-------------------|-------------|--------|
				-------------------|--------| Mods I always want to use | Long Reach		| 2			  | True   |
				Long Reach		   |  True  |						    | Squik Through	    |			  |		   |		 
				-------------------|--------|						    |				    |			  |		   |
				Squik Through	   |  True  |						    | 				    |			  |		   |
				-------------------|--------|						    |				    |			  |		   |
				Bob's Ores		   |  False |---------------------------|-------------------|-------------|--------|
				-------------------|--------|