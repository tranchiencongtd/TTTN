const backBtn = document.querySelector('#backBtn');
const nextBtn = document.querySelector('#nextBtn');
const submitBtn = document.querySelector('#submit');
const question = document.querySelector('.question');
const answers = document.querySelector('.answers');
const total = document.querySelector('#total');

let currentQuestion = 0;
let nextQuestion;
let userAnswers = [];

window.onload = () => {
  backBtn.disabled = true;
  submitBtn.style.display = 'none';
  showQuestion(0);
};

backBtn.addEventListener('click', () => {
  userPick(currentQuestion);
  nextQuestion = currentQuestion - 1;
  if (currentQuestion == myQuestions.length - 1) {
    nextBtn.style.display = 'inline-block';
    submitBtn.style.display = 'none';
  }
  if (nextQuestion >= 0) {
    currentQuestion--;
    clearQuestion();
    showQuestion(currentQuestion);
  }
  if (currentQuestion == 0) {
    nextBtn.disabled = false;
    backBtn.disabled = true;
  }
});

nextBtn.addEventListener('click', () => {
  userPick(currentQuestion);
  nextQuestion = currentQuestion + 1;
  if (nextQuestion <= myQuestions.length - 1) {
    currentQuestion++;
    clearQuestion();
    showQuestion(currentQuestion);
  }
  if (currentQuestion == myQuestions.length - 1) {
    nextBtn.style.display = 'none';
    submitBtn.style.display = 'inline-block';
    submitBtn.style.color = 'blue';
  }
  if (currentQuestion != 0) {
    backBtn.disabled = false;
  }
});

submitBtn.addEventListener('click', () => {
  userPick(currentQuestion);

  total.innerText = 'You have ' + calcPoint() + ' correct answer!';
});

const showQuestion = (num) => {
  question.innerText = `Question ${num + 1}: ${myQuestions[num].question}`;
  for (letter in myQuestions[num].answers) {
    let element;

    if (letter == userAnswers[num]) {
      element = `
        <label>
        <input type="radio" name="question${num}" value="${letter}" checked>
        ${letter}.
        <span>${myQuestions[num].answers[letter]}</span>
        <br>
      </label>`;
    } else {
      element = `
      <label>
      <input type="radio" name="question${num}" value="${letter}">
      ${letter}.
      <span>${myQuestions[num].answers[letter]}</span>
      <br>
    </label>`;
    }

    answers.insertAdjacentHTML('beforeend', element);
  }
};

const clearQuestion = () => {
  answers.innerHTML = '';
  question.innerHTML = '';
};

const userPick = (num) => {
  const selector = `input[name=question${num}]:checked`;
  const answer = (document.querySelector(selector) || {}).value;
  console.log(answer);
  userAnswers[num] = answer;
};

const calcPoint = () => {
  let numAnswerCorrect = 0;
  myQuestions.map((el, i) => {
    if (el.correctAnswer === userAnswers[i]) numAnswerCorrect++;
  });
  return numAnswerCorrect;
};
const myQuestions = [
  {
    question: 'Javascript is _________ language.',
    answers: {
      a: 'Programming',
      b: 'Application',
      c: 'None of These',
      d: 'Scripting',
    },
    multi: false,
    correctAnswer: 'd',
  },
  {
    question:
      'Which of the following is a valid type of function javascript supports?',
    answers: {
      a: 'named function',
      b: 'anonymous function',
      c: 'both of the above',
      d: 'none of the above',
    },
    multi: false,
    correctAnswer: 'c',
  },
  {
    question:
      'Which built-in method returns the index within the calling String object of the first occurrence of the specified value?',
    answers: {
      a: 'getIndex()',
      b: 'location()',
      c: 'indexOf()',
      d: 'getLocation()',
    },
    multi: false,
    correctAnswer: 'c',
  },
  {
    question: 'Which one of the following is valid data type of JavaScript',
    answers: {
      a: 'number',
      b: 'void',
      c: 'boolean',
      d: 'nothing',
    },
    multi: false,
    correctAnswer: 'c',
  },
];
