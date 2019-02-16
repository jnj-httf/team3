Quando("acesso a URL") do
    visit('')
end

Então("eu verifico se estou na página correta") do
    expect(page).to have_current_path('https://github.com/jnj-httf/team3', url:true)
end