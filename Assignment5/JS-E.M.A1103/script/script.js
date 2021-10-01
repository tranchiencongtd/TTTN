let theImages = [
  {
    src: 'https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ',
    width: '300',
    height: '300',
  },
  {
    src: 'https://i.picsum.photos/id/1001/5616/3744.jpg?hmac=38lkvX7tHXmlNbI0HzZbtkJ6_wpWyqvkX4Ty6vYElZE',
    width: '300',
    height: '300',
  },
  {
    src: 'https://i.picsum.photos/id/1010/5184/3456.jpg?hmac=7SE0MNAloXpJXDxio2nvoshUx9roGIJ_5pZej6qdxXs',
    width: '300',
    height: '300',
  },
  {
    src: 'https://i.picsum.photos/id/1005/5760/3840.jpg?hmac=2acSJCOwz9q_dKtDZdSB-OIK1HUcwBeXco_RMMTUgfY',
    width: '300',
    height: '300',
  },
  {
    src: 'https://i.picsum.photos/id/100/2500/1656.jpg?hmac=gWyN-7ZB32rkAjMhKXQgdHOIBRHyTSgzuOK6U0vXb1w',
    width: '300',
    height: '300',
  },
  {
    src: 'https://i.picsum.photos/id/102/4320/3240.jpg?hmac=ico2KysoswVG8E8r550V_afIWN963F6ygTVrqHeHeRc',
    width: '300',
    height: '300',
  },
];

const imageContainer = document.querySelector('.imageContainer');
const genderrateBtn = document.querySelector('#genderate');

const randomNum = (min, max) => {
  let arr = [];
  while (arr.length < 3) {
    let num = Math.floor(Math.random() * max) + min;
    if (arr.indexOf(num) === -1) arr.push(num);
  }
  return arr;
};

genderrateBtn.addEventListener('click', () => {
  const imagePicks = randomNum(0, theImages.length - 1);
  console.log(imagePicks);
  document
    .querySelector('.img1 img')
    .setAttribute('src', theImages[imagePicks[0]].src);
  document
    .querySelector('.img2 img')
    .setAttribute('src', theImages[imagePicks[1]].src);
  document
    .querySelector('.img3 img')
    .setAttribute('src', theImages[imagePicks[2]].src);
});
