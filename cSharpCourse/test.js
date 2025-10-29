const array = [1, 2, 3, 4, 5];

for (const element of array) {
    console.log('Element:', element);
}

for (const key in array) {
    if (!Object.hasOwn(array, key)) continue;

    const element = array[key];
    
    console.log('Key:', key, 'Element:', element);
    console.log('Array contents:', array);
    console.log('Array keys:', Object.keys(array));

}


const a = 3;
const _negativeOrZero = a < 0 ? "Negative" : "Zero";
const t = a > 0 ? "Positive" : _negativeOrZero;
console.log('Switch result:', t);

