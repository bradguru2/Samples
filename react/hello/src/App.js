import React from 'react';
import logo from './logo.svg';
import './App.css';

function Square(props) {
  return (
    <button className="square" onClick={props.onClick}>
      {props.value}
    </button>
  );
}

class Board extends React.Component {
  renderSquare(i) {
    return (
      <Square
        value={this.props.squares[i]}
        onClick={() => this.props.onClick(i)}
      />
    );
  }

  render() {
    return (
      <div>
        
        <div className="board-row">
          {this.renderSquare(0)}
          {this.renderSquare(1)}
          {this.renderSquare(2)}
        </div>
        <div className="board-row">
          {this.renderSquare(3)}
          {this.renderSquare(4)}
          {this.renderSquare(5)}
        </div>
        <div className="board-row">
          {this.renderSquare(6)}
          {this.renderSquare(7)}
          {this.renderSquare(8)}
        </div>
      </div>
    );
  }
}

function calculateWinner(squares) {
  const lines = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6],
  ];

  for (let i = 0; i < lines.length; i++) {
    const [a, b, c] = lines[i];
    if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
      return squares[a];
    }
  }
  
  return null;
}

function isMoreMoves(squares){
  for(var value of squares){
    if(value === null){
      return true;
    }
  }

  return false;
}

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      history: [{
        squares: Array(9).fill(null),
      }],
      xIsNext: true,
      stepNumber: 0,
    };
  }

  getAvailableMoves(squares){
    let moves = [];

    for(let i=0; i < squares.length; i++){
      if(squares[i] === null){
        moves.push({ index: i, score: null });
      }
    }
    
    return moves;
  }

  miniMax(squares, player){
    let win = calculateWinner(squares);
    let cmpScore = player === 'O' ? -20 : 20;
    let spots = this.getAvailableMoves(squares);

    if(win != null){
      if(win === 'O'){
        return {score:10};
      }
      else {
        return {score:-10};
      }
    }
    else if(spots.length === 0){
      return {score:0};
    }

    let moves = [];
    for (var spot of spots) {
      squares[spot.index] = player;
      spot.score = this.miniMax(squares, player === 'O' ? 'X' : 'O').score;
      squares[spot.index] = null;
     
      if ((player === 'X' && spot.score === -10) || (player === 'O' && spot.score === 10)) {
        return spot;
      }
      else{
        moves.push(spot);
      }
    }

    let bestMove = null;
    for(var move of moves){
      if(player === 'O' && move.score > cmpScore){
        bestMove = move;
        cmpScore = move.score;
      }
      else if(player === 'X' && move.score < cmpScore){
        bestMove = move;
        cmpScore = move.score;
      }
    }

    return bestMove;
  }

  bestSpot(squares){
    let spot = this.miniMax(squares, 'O');
    //alert('(' + spot.score + ',' + spot.index + ')');
    return spot.index;
  }

  computerTurn(){
    const history = this.state.history.slice(0, this.state.stepNumber + 1);
    const current = history[history.length - 1];
    const squares = current.squares.slice();

    let moves = this.getAvailableMoves(squares);

    if(moves.length === 0 || calculateWinner(squares)){
      return;
    }

    squares[this.bestSpot(squares)] = 'O';

    this.setState({
      history: history.concat([{
        squares: squares,
      }]),
      stepNumber: history.length,
      xIsNext: !this.state.xIsNext,
    });
  }

  handleClick(i) {
    const history = this.state.history.slice(0, this.state.stepNumber + 1);
    const current = history[history.length - 1];
    const squares = current.squares.slice();
    
    if (!this.state.xIsNext || calculateWinner(squares) || squares[i]) {
      return;
    }

    squares[i] = this.state.xIsNext ? 'X' : 'O';

    setTimeout(function lambda(){this.computerTurn()}.bind(this), 50);

    this.setState({
      history: history.concat([{
        squares: squares,
      }]),
      stepNumber: history.length,
      xIsNext: !this.state.xIsNext
    });
  }

  jumpTo(step) {
    this.setState({
      stepNumber: step,
      xIsNext: (step % 2) === 0,
    });

    if(step % 2 === 1) 
      setTimeout(function lambda(){this.computerTurn()}.bind(this), 50);
  }

  render() {
    const history = this.state.history;
    const current = history[this.state.stepNumber];
    const winner = calculateWinner(current.squares);
    
    const moves = history.map((step, move) => {
      const desc = move ?
        'Go to move #' + move :
        'Go to game start';
      return (
        <li key={move}>
          <button onClick={() => this.jumpTo(move)}>{desc}</button>
        </li>
      );
    });

    let status;
    let tie = !isMoreMoves(current.squares);

    if (winner) {
      status = 'Winner: ' + winner;
    } else if(tie){
      status = 'Tie';
    } else {
      status = 'Next player: ' + (this.state.xIsNext ? 'X' : 'O');
    }
    
    return (
      <div className="app">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to Tic Tac Toe</h1>
        </header>
 
        <div className="game">
          <div className="game-board">
            <Board
              squares={current.squares}
              onClick={(i) => this.handleClick(i)}
            />
          </div>
          <div className="game-info">
            <div>{status}</div>
            <ol>{moves}</ol>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
