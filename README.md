# VocabVersus
**VocabVersus** is a **web-based** multiplayer vocabulary game, in this game multiple players will compete to think of a word containing given letters. 
Points will be given based on **player’s speed** and **complexity** of the word given, along with the **popularity of the given word**.


## Similar Contexts
Similar games based on creating/guessing words already exist such as [Scrabble](https://playscrabble.com/) or [Wordle](https://www.nytimes.com/games/wordle/index.html) and games such as [scribble.io](https://skribbl.io/) is similar in its functionality/behavior.

## Roadmap
- [ ] Dashboard / Landing page
	- [ ] Game Creator
	- [ ] Custom game rules 
	- [ ] WordSet importer
- [ ] Game Interface
	- [x] Realtime game connectivity
	- [x] Game instance joining
	- [ ] Gameplay
		- [ ] Pre start lobby
		- [ ] Player management
		- [ ] Session storing
		- [ ] Match Session
			- [ ] Letter showcase
			- [ ] Input feedback
			- [ ] Event feedback
- [ ] Game Engine
	- [x] Game instance initializer
	- [x] System for receiving game input and returning game information
	- [x] Player connection system handling player - game instance communication
	- [ ] Persistent player sessions
	- [ ] Word Aggregation connection
	- [ ] Game instance password protection
	- [ ] Match session handler
		- [ ] Event handler 
- [ ] Game data storage
	- [ ] Word usage tracker
- [ ] Word Aggregation
	- [ ] Word validator, word - wordset finder
	- [ ] WordSet importing
- [ ] Deployment pipeline

## Diagrams
<img src="Documentation/Assets/VocabVersus.drawio.png" alt="C4 architectural design diagram" width="500">

## Cloud Hosts