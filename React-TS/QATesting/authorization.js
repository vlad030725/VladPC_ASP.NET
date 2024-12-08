async function authorization(page) {
    await page.goto("http://localhost:3000/login")
    const loginInput = await page.$('input[name="login"]');
    const passwordInput = await page.$('input[name="password"]');
    if (loginInput && passwordInput) {
        console.log('Элемент найден');
        await loginInput.type('user');
        await passwordInput.type('Aa123456!');
        const loginButton = await page.$('button.ant-btn.ant-btn-primary[type="submit"]');
        if (loginButton) {
            console.log('Кнопка найдена');
            loginButton.click()
        } else {
            console.log('Кнопка не найдена');
        }
    } else {
        console.log('Элемент не найден');
    }
}

module.exports = authorization;