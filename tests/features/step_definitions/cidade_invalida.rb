Quando("digito uma cidade inválida") do
	isit('/buscar-ubs.html')
    fill_in(id: 'inputCidade', with: 'Cidade JNJ')
    find('input[value="Buscar UBS"]').click
end

Entao("verifico se um erro é exibido") do
	texto = find('#erro_cidade')
    expect(texto.text).to eql 'A cidade digitada é inválida'
end