const urlImage = [
  'https://i-vnexpress.vnecdn.net/2020/09/22/smilling-shiba-pics-1-5f684c7f-3655-6553-1600769370_m_460x0.jpg',
  'https://sohanews.sohacdn.com/160588918557773824/2020/7/7/photo-3-1594135220019974813055.jpg',
  'https://tunglocpet.com/wp-content/uploads/2021/02/chu-cho-shiba-noi-tieng-07.jpg',
  'https://media-cdn.laodong.vn/Storage/NewsPortal/2020/3/6/788908/Cho-1.jpg',
];

const image = document.querySelector('.image img');
const backBtn = document.querySelector('#backBtn');
const nextBtn = document.querySelector('#nextBtn');

let currentImage = 0;
let nextImage;

window.onload = () => {
  image.setAttribute('src', urlImage[currentImage]);
  backBtn.disabled = true;
};

backBtn.addEventListener('click', () => {
  nextImage = currentImage - 1;
  if (nextImage >= 0) {
    currentImage--;
    image.setAttribute('src', urlImage[nextImage]);
  }
  if (currentImage == 0) {
    nextBtn.disabled = false;
    backBtn.disabled = true;
  }
});

nextBtn.addEventListener('click', () => {
  nextImage = currentImage + 1;
  if (nextImage <= urlImage.length - 1) {
    currentImage++;
    image.setAttribute('src', urlImage[nextImage]);
  }
  if (currentImage == urlImage.length - 1) {
    nextBtn.disabled = true;
    backBtn.disabled = false;
  }
});
