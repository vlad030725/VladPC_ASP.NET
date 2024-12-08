const puppeteer = require("puppeteer")

async function testCaseAddTypeProduct() {
    console.log("Запуск браузера")
    const browser = await puppeteer.launch({ headless: false, slowMo: 100 })

    console.log("Открыть вкладку браузера")
    const page = await browser.newPage()

    console.log("Открыть страницу")
    await page.goto("http://localhost:3000/")

    console.log("Задать разрешение страницы")
    await page.setViewport({ width: 1080, height: 1024 })

    //Авторизация
    await page.goto("http://localhost:3000/login")
    const loginInput = await page.$('input[name="login"]');
    const passwordInput = await page.$('input[name="password"]');
    if (loginInput && passwordInput) {
        console.log('Элемент найден');
        await loginInput.type('admin');
        await passwordInput.type('Aa123456!');
    } else {
        console.log('Элемент не найден!!!');
        return;
    }

    const loginButton = await page.$('button.ant-btn.ant-btn-primary[type="submit"]');
    if (loginButton) {
        console.log('Кнопка найдена');
        loginButton.click()
    } else {
        console.log('Кнопка не найдена!!!');
        return;
    }

    await page.waitForSelector('li[style*="opacity: 1;"][style*="order: 4;"]');
    const listItem = await page.$('li[style*="opacity: 1;"][style*="order: 4;"]');
    
    if (listItem) {
        console.log('Элемент найден');
        await listItem.click();
    } else {
        console.log('Элемент не найден!!!');
        return;
    }

    const spans = await page.$$('span'); // Находим все элементы <span>
    let targetSpan = null;

    for (const span of spans) {
        const text = await page.evaluate(el => el.textContent.trim(), span);
        if (text === 'Добавить тип продукта') {
            targetSpan = span;
            break;
        }
    }

    if (targetSpan) {
        console.log('Элемент найден');
        await targetSpan.click();
    } else {
        console.log('Элемент не найден!!!');
        return;
    }

    const inputSelector = 'input[name="nameTypeProduct"]';

    await page.waitForSelector(inputSelector);
    const input = await page.$(inputSelector);

    if (input) {
        console.log('Элемент найден');
        await input.type('Test TypeProduct');
        console.log('Текст успешно введён');
    } else {
        console.log('Элемент не найден!!!');
        return;
    }

    await page.waitForSelector('span');

    const spans2 = await page.$$('span');
    let targetSpan2 = null;

    for (const span of spans2) {
        const text = await page.evaluate(el => el.textContent.trim(), span);
        if (text === 'Save') {
            targetSpan2 = span;
            break;
        }
    }

    if (targetSpan2) {
        console.log('Элемент найден');
        await targetSpan2.click();
    } else {
        console.log('Элемент не найден!!!');
        return;
    }

    await page.waitForSelector('td');

    const cells = await page.$$('td');
    let targetCell = null;

    for (const cell of cells) {
        const text = await page.evaluate(el => el.textContent.trim(), cell);
        if (text === 'Test TypeProduct') {
            targetCell = cell;
            break;
        }
    }

    if (targetCell) {
        console.log('Элемент найден');
    } else {
        console.log('Элемент не найден!!!');
        return;
    }


    console.log("Закрыть браузер")
    await browser.close()
    console.log('Тест пройден');
}

testCaseAddTypeProduct()